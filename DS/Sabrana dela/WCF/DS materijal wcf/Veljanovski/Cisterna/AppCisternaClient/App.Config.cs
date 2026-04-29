<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
    </startup>
    <system.serviceModel>
        <bindings>
            <basicHttpBinding>
                <binding name="BasicHttpBinding_ICisterna" />
            </basicHttpBinding>
        </bindings>
        <client>
            <endpoint address="http://localhost:53367/Cisterna.svc" binding="basicHttpBinding"
                bindingConfiguration="BasicHttpBinding_ICisterna" contract="CisternaServiceReference.ICisterna"
                name="BasicHttpBinding_ICisterna" />
        </client>
    </system.serviceModel>
</configuration>