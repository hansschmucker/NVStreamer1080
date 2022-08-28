using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace NVStreamer1080 {
    public class AutoAction {
        public AutoAction() { }
        public AutoAction(string json) {
            FromJSON(json);
        }

        public AutoAction(Dictionary<string, object> data) {
            FromDictionary(data);
        }

        public void FromJSON(string json) {
            var data=JSON.Deserialize<Dictionary<string, object>>(json);
            FromDictionary(data);
        }

        public void FromDictionary(Dictionary<string, object> data) {
            TargetAction = !data.ContainsKey("Action") ? ActionType.Open : (ActionType)((int)data["Action"]);
            Process = !data.ContainsKey("Process") ? "" : (string)data["Process"];
            WorkingDirectory = !data.ContainsKey("Cwd") ? "" : (string)data["Cwd"];
            Args = !data.ContainsKey("Arg") ? "" : (string)data["Arg"];
            Delay = !data.ContainsKey("Delay") ? 0 : (int)data["Delay"];
            AbortOnInput = data.ContainsKey("Interrupt") && (bool)data["Interrupt"];
        }

        internal JavaScriptSerializer JSON = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue };
        public enum ActionType {
            Open,
            Close,
            Kill,
            Exit,
            Standby,
            Hibernate
        }

        public ActionType TargetAction=ActionType.Exit;
        public string Process = "";
        public string WorkingDirectory = "";
        public string Args = "";
        public int Delay = 0;
        public bool AbortOnInput = false;
        public override string ToString() {
            return (
                TargetAction == ActionType.Open ? "Launch " + Process :
                TargetAction == ActionType.Close ? "Close " + Process :
                TargetAction == ActionType.Kill ? "Kill " + Process :
                TargetAction == ActionType.Exit ? "Kill Stream" :
                TargetAction == ActionType.Standby ? "Sleep" :
                TargetAction == ActionType.Hibernate ? "Hibernate" :
                "Unknown Action"
                )+", "+Delay+"s delay"+(AbortOnInput?" Abort on Input":"");
        }

        public string ToJSON() {
            return JSON.Serialize(ToDictionary()); 
        }

        public Dictionary<string, object> ToDictionary() {
            return (new Dictionary<string, object>() {
                { "Action",(int)TargetAction },
                { "Process",Process },
                { "Cwd",WorkingDirectory },
                { "Arg",Args },
                { "Delay",Delay },
                { "Interrupt",AbortOnInput}
            });
        }

        public void Execute() {
            switch (TargetAction) {
                case ActionType.Open:
                    var p = new ProcessStartInfo() {
                        FileName = Process,
                        Arguments = Args,
                        WorkingDirectory = WorkingDirectory
                    };
                    try {
                        System.Diagnostics.Process.Start(p);
                    } catch (Exception) { }
                    break;
                case ActionType.Close: {
                        var procs = System.Diagnostics.Process.GetProcesses().Where(a => a.ProcessName.ToLower() == Process.ToLower());
                        foreach (var proc in procs)
                            try {
                                proc.Close();
                            } catch (Exception) { }
                    }
                    break;
                case ActionType.Kill: {
                        var procs = System.Diagnostics.Process.GetProcesses().Where(a => a.ProcessName.ToLower() == Process.ToLower());
                        foreach (var proc in procs)
                            try {
                                proc.Kill();
                            } catch (Exception) { }
                    }
                    break;
                case ActionType.Exit: {
                        var procs = System.Diagnostics.Process.GetProcesses().Where(a => a.ProcessName.ToLower() == "nvstreamer");
                        foreach (var proc in procs)
                            try {
                                proc.Close();
                            } catch (Exception) { }
                    }
                    break;
                case ActionType.Standby: {
                        Application.SetSuspendState(PowerState.Suspend, true, true);
                    }
                    break;
                case ActionType.Hibernate: {
                        Application.SetSuspendState(PowerState.Hibernate, true, true);
                    }
                    break;
            }
        }
    }
}
