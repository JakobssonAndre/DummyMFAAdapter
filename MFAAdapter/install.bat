.\gacutil.exe /if 'DummyMFAAdapter.dll'
.\gacutil.exe /l DummyMFAAdapter

# You need the PublicKeyToken acquired by running the commands above
$typeName = "ADFSMFAdapters.MFAAdapter, MFAMFAAdapter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=xyz, processorArchitecture=MSIL"
Register-AdfsAuthenticationProvider -TypeName $typeName -Name "MFA Adapter" -ConfigurationFilePath 'C:\install\MFA Adapter\MFAAdapter.json'
net stop adfssrv
net start adfssrv

Get-AdfsAuthenticationProvider
