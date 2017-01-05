# MyRunUO_MySQL
You need to install the .NET MySQL Conector to use this.  

#Optional installing .NET MySQL Connector
#create a working directory (i.e. mysql)
Code (C#):
 
mkdir mysql
cd mysql
 
#Download the connector
Code (C#):
 
wget https://dev.mysql.com/get/Downloads/Connector-Net/mysql-connector-net-6.9.9-noinstall.zip
unzip mysql-connector-net-6.9.9-noinstall.zip
 
#Now add the 4.0 libs
Code (C#):
 
cd v4.0
sudo gacutil /i /package 4.0 MySql.Data.dll
 
#You should see:
#Package exported to: /opt/local/lib/mono/4.0/MySql.Data.dll -> ../gac/MySql.Data/6.8.3.0__c5687fc88969c44d/MySql.Data.dll
#Installed MySql.Data.dll into the gac (/opt/local/lib/mono/gac)

#Now the 4.5 libs
Code (C#):
 
cd ../v4.5
sudo gacutil /i /package 4.5 MySql.Data.dll
 
Package exported to: /opt/local/lib/mono/4.5/MySql.Data.dll -> ../gac/MySql.Data/6.8.3.0__c5687fc88969c44d/MySql.Data.dll
Installed MySql.Data.dll into the gac (/opt/local/lib/mono/gac)

#verify
Code (C#):
 
gacutil -l|grep MySql
 
#MySql.Data, Version=6.9.9.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d


#To use these in any of your ServUO scripts, you need to update the Makefile
Code (C#):
 
nano Makefile
 
#Change this:
REFS=System.Drawing.dll

#To this:
REFS=System.Drawing.dll,System.Data.dll,/usr/local/lib/mono/4.0/MySql.Data.dll

#This save
#Add this to your scripts to use:
Code (C#):
 
using MySql.Data;
using MySql.Data.MySqlClient;
 
#If you are getting errors about MySql assembly reference, you may need to update your machine.config files
Code (C#):
 
/etc/mono/4.0/machine.config
/etc/mono/4.5/machine.config
/usr/local/etc/mono/4.0/machine.config
/usr/local/etc/mono/4.5/machine.config
 
#Edit these files, search for <system.data> and add this inside <DbProviderFactories>
Code (C#):
 
            <add name="MySQL Data Provider" invariant="MySql.Data.MySqlClient"
                 description=".Net Framework Data Provider for MySQL"
                 type="MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, Version=6.9.9.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d" />
                 
Now, edit your  /Data/Assemblies.cfg file and add MySql.Data.dll   

You should be able to compile now.
                 
And lastly, copy the MySql.Data.dll file to the same directory where your Makefile is there are problems finding it when you compile.
