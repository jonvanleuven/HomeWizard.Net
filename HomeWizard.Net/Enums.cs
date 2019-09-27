﻿namespace HomeWizard.Net
{
    public enum OnOff
    {
        Off,
        On
    }

    public enum YesNo
    {
        Null,
        No,
        Yes
    }

    public enum SwitchType
    {
        Switch,
        Dimmer,
        Hue,
        Somfy,
        Virtual
    }

    public enum KakuSensorType
    {
        Motion,
        Contact,
        Contact868,
        Smoke,
        Camera,
        Doorbell
    }

    public enum Preset
    {
        Home = 0,
        Away = 1,
        Sleep = 2,
        Holiday = 3
    }

    public enum Day
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6
    }

    public enum TriggerType
    {
        Time,
        Preset
    }
}
