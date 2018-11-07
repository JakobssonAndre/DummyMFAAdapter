Unregister-AdfsAuthenticationProvider -Name "Dummy MFA Adapter"
net stop adfssrv
net start adfssrv
.\gacutil.exe /u "DummyMFAAdapter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=xyz, processorArchitecture=MSIL"
