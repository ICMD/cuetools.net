using CUETools.CTDB;
using CUETools.Processor;

CUEConfig config = new CUEConfig();
config.writeArLogOnConvert = false;
CUESheet cueSheet = new CUESheet(config);

cueSheet.CUEToolsProgress += (object? sender, CUEToolsProgressEventArgs e) =>
{
    if (e.status.Length > 0) Console.WriteLine(e.status);
};

cueSheet.CUEToolsSelection += (object? sender, CUEToolsSelectionEventArgs e) =>
{
    if (e.choices.Length == 0) return;
    List<DBEntry> dbEntries = e.choices
    .Select(choice => (DBEntry)((CUEToolsSourceFile)choice).data)
    .ToList();
    DBEntry dbEntry = dbEntries.MaxBy(dbEntry => dbEntry.conf)!;
    e.selection = dbEntries.IndexOf(dbEntry);
};

string cueFile = args[0]; // cue sheet of single `.bin` file
string wavFile = Path.ChangeExtension(cueFile, ".wav");

cueSheet.Open(cueFile);
cueSheet.GenerateFilenames(AudioEncoderType.Lossless, "wav", wavFile);

CUEToolsScript script = new CUEToolsScript("repair", Array.Empty<CUEAction>());
string status = cueSheet.ExecuteScript(script);
Console.WriteLine(status);
