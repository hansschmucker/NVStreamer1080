# NVStreamer1080
Utility to automatically detect NVidia GameStream activity and set a fitting resolution or switch to a second screen.

Written for personal use, so don't expect too much, it basically:

1. Either changes resolution or
2. Switches to the external display

when it detects GameStream activity, then afterwards depending on mode

1. Returns to the original resolution
2. Returns to the internal display

It automatically hides itself on launch, if you want to get to the settings, look for an ugly icon in your systray.
Oh, and it automatically registers to autostart on first run. If you want to update just close it in the Systray and paste the new EXE from the release page over the previous one.

What it doesn't do:
Anything clever really. In second-screen-mode it really just switches to external then back to internal. So if you (for example) have three screens, it probably won't do what you want.
