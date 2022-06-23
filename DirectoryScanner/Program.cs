using DirectoryScanner.BLL;

var scan = new Scanner();
scan.ScanDirectory(@"C:\Users\povvel\Documents\SQL Server Management Studio\CramoAppLT-PROJECTS\GinHubRepository\CREDITS");
scan.SaveChanges();
