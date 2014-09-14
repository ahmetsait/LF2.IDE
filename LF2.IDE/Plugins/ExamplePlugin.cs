using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LF2.IDE;

//public abstract class Plugin
//{
//	public virtual string Name { get { return null; } }
//	public virtual string Author { get { return null; } }
//	public virtual string IdeVersion { get { return null; } }
//	public virtual string Description { get { return null; } }
//	public virtual string Warning { get { return null; } }
//	public virtual string Web { get { return null; } }

//	protected MainForm MainForm { get { return Program.MainForm; } }

//	public abstract void Register();
//	public virtual void Unregister() { }
//	public virtual void OnExit(CloseReason closeReason) { }
//}

public class ExamplePlugin : Plugin
{
	public override string Name { get { return "Example Plugin"; } }
	public override string Author { get { return "NightmareX"; } }
	public override string IdeVersion { get { return "1.7"; } }
	public override string Description { get { return "It makes an example"; } }
	public override string Warning { get { return "It's not useful"; } }
	public override string Web { get { return "http://www.lf-empire.de/forum/showthread.php?tid=9064"; } }

	ToolStripMenuItem entry;

	public ExamplePlugin()
	{
		entry = new ToolStripMenuItem("Example Plugin");
		entry.DropDownItems.Add("Do Some Stuff", null, (sender, e) => MessageBox.Show("Test"));
	}

	public override void Register()
	{
		MainForm.mainMenuStrip.Items.Add(entry);
	}

	public override void Unregister()
	{
		MainForm.mainMenuStrip.Items.Remove(entry);
	}
}
