## 1. SqlExpress: a standalone database server

### Download

Go to:

https://www.microsoft.com/en-us/sql-server/sql-server-downloads

### Install the “Express” edition (on the right side of the following screenshot):

Chose: “Download now”

![image-20210310162630864](./sqlexpress1.png)                          

Install everything but “SQL Server Reporting Services”. We start by clicking on “New SQL Server stand-alone installation or add features to an existing installation”.

 

 ![image-20210310162649227](./sqlexpress2.png)

Chose “Custom”:

 ![image-20210310162700860](./sqlexpress3.png)

 

 ![image-20210310162711772](./sqlexpress4.png)

Accept license terms:

 ![image-20210310162723578](./sqlexpress5.png)

Select “Use Microsoft Update”:

 ![image-20210310162732418](./sqlexpress6.png)

 ![image-20210310162743136](./sqlexpress7.png)

  ![image-20210310162753202](./sqlexpress8.png)

![image-20210310162807700](./sqlexpress9.png)

We will open up the required network ports later on, using a script:

 ![image-20210310162816857](./sqlexpress10.png)

Keep current selection:

 ![image-20210310162825203](./sqlexpress11.png)

Keep proposed name (named instance was “SqlExpress” on another computer):

 ![image-20210310162834637](./sqlexpress12.png)

 ![image-20210310162844350](./sqlexpress13.png)

Keep default configuration:

 ![image-20210310162856240](./sqlexpress14.png)

 You can chose to use only “Windows authentication mode” or mixed mode (Windows authentication mode and user/password):

 ![image-20210310162905765](./sqlexpress15.png)

 ![image-20210310162915290](./sqlexpress16.png)

 ![image-20210310162927162](./sqlexpress17.png)

 ![image-20210310162935897](./sqlexpress18.png)

![image-20210310162943699](./sqlexpress19.png)

## 2.  Install SQL Server Management Studio

Go to:

https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15

 ![image-20210310162953510](./sqlexpress20.png)

 ![image-20210310163001229](./sqlexpress21.png)

Go to:

https://docs.microsoft.com/en-us/sql/ssdt/download-sql-server-data-tools-ssdt?view=sql-server-ver15

 ![image-20210310163019065](./sqlexpress22.png)

 ![image-20210310163027094](./sqlexpress23.png)

Do not install:

 ![image-20210310163037346](./sqlexpress24.png)



## 3.  Configure SQL Server

 ![image-20210310163045448](./sqlexpress25.png)

- ·     Enable Named Pipes
- ·     Enable TCP/IP

Restart SqlServer.

## 4.  Open ports firewall

https://docs.microsoft.com/en-us/sql/sql-server/install/configure-the-windows-firewall-to-allow-sql-server-access?view=sql-server-ver15

 ![image-20210310163059021](./sqlexpress26.png)

 

```
netsh firewall set portopening protocol = TCP port = 1433 name = SQLPort mode = ENABLE scope = SUBNET profile = CURRENT
```

As Administrator:

```
netsh advfirewall firewall add rule name = SQLPort dir = in protocol = tcp action = allow localport = 1433 remoteip = localsubnet profile = DOMAIN
```

## 5.  NorthWind, Pubs and AdventureWorks example databases

https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql/linq/downloading-sample-databases

https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs

**Run the scripts in SSMS**

1. Open SSMS.
2. Connect to the target SQL Server.
3. Open the script in a new query window.
4. Run the script.

**Run the scripts in SSDT or Visual Studio**

1. Open SSDT or Visual Studio.
2. Open the SQL Server Object Explorer.
3. Connect to the target SQL Server.
4. Open the script in a new query window.
5. Run the script.

 

 ![image-20210310163115044](./sqlexpress27.png)

![image-20210310163123630](./sqlexpress28.png)

Copy to C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup:

 ![image-20210310163131676](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\sqlexpress29.png)

Restore using SQLServer Management Studio:

 ![image-20210310163138828](./sqlexpress30.png)

Refresh:

 ![image-20210310163146763](./sqlexpress31.png)

AdventureWorks:

https://github.com/Microsoft/sql-server-samples/releases/tag/adventureworks

 ![image-20210310163200833](./sqlexpress32.png)

## 6.  Northwind database

 ![image-20210310163208950](./sqlexpress33.png)

## 7.  Upgrading

https://medium.com/cloudnimble/upgrade-visual-studio-2019s-localdb-to-sql-2019-da9da71c8ed6