using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arby.dataclass;
using Arby.util;
using Newtonsoft.Json;
using System.IO;
using Equin.ApplicationFramework;

namespace Arby
{
    public partial class SnapshotManager : Form
    {
        Dictionary<long, List<MarketSnapshot>> OriginalDatabase;
        public Dictionary <long, List<MarketSnapshot>> WorkspaceDatabase = new Dictionary<long, List<MarketSnapshot>>();
        Dictionary<long, List<MarketSnapshot>> ImportedDatabase = new Dictionary<long, List<MarketSnapshot>>();
        public SnapshotManager()
        {
            InitializeComponent();
        }

        public SnapshotManager(Dictionary<long, List<MarketSnapshot>> database)
        {
            InitializeComponent();
            OriginalDatabase = database;
            ImportedEventSnapshotsView.AutoGenerateColumns = true;
            WorkspaceEventSnapshotsView.AutoGenerateColumns = true;

        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            FileSelectDialog.InitialDirectory = Directory.GetCurrentDirectory();
            if (FileSelectDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ImportedDatabase = JsonFileSerializer.DeserializeSnapshotsFromJson(FileSelectDialog.OpenFile());
                    UpdateImportedEventsBox();
                }
                catch (Exception Ex)
                {
                    if (Ex is JsonSerializationException || Ex is JsonReaderException)
                    {
                        GUIHelper.ThrowWarning("File error", "Deserialization failed. Make sure to select the right file.");
                    }
                }
            }
        }

        private void UpdateImportedEventsBox()
        {
            List<Tuple<string, long>> EventNames = new List<Tuple<string, long>>();
            foreach (var Event in ImportedDatabase)
            {
                if (Event.Value.Count() > 0)
                {
                    EventNames.Add(new Tuple<string, long>(Event.Value[0].Name, Event.Key));
                }
            }
            ImportedEventsBox.DataSource = EventNames;
            ImportedEventsBox.ValueMember = "Item2";
            ImportedEventsBox.DisplayMember = "Item1";
            UpdateImportedEventsSnapshotsView();
        }

        private void UpdateWorkspaceEventsBox()
        {
            List<Tuple<string, long>> EventNames = new List<Tuple<string, long>>();
            foreach (var Event in WorkspaceDatabase)
            {
                if (Event.Value.Count() > 0)
                {
                    EventNames.Add(new Tuple<string, long>(Event.Value[0].Name, Event.Key));
                }
            }
            WorkspaceEventsBox.DataSource = EventNames;
            WorkspaceEventsBox.ValueMember = "Item2";
            WorkspaceEventsBox.DisplayMember = "Item1";
            UpdateWorkspaceEventSnapshotsView();
        }

        private void UpdateImportedEventsSnapshotsView()
        {
            ImportedEventSnapshotsView.DataSource = null;
            if (ImportedEventsBox.SelectedValue is long EventID)
            {
                List<MarketSnapshot> Snapshots = ImportedDatabase[EventID];

                ImportedRunnerFilterBox.DataSource =  Snapshots.Select(x => x.Runner).Distinct().ToList();    
                ImportedMarketFilterBox.DataSource = Snapshots.Select(x => x.Market).Distinct().ToList();
           
                BindingListView<MarketSnapshot> View = new BindingListView<MarketSnapshot>(Snapshots);
                ImportedEventSnapshotsView.DataSource = View;
                ImportedEventSnapshotsView.Columns["MatchID"].Visible = false; // hide unwanted columns
                ImportedEventSnapshotsView.Columns["Name"].Visible = false;
            }

        }

        private void UpdateWorkspaceEventSnapshotsView()
        {
            WorkspaceEventSnapshotsView.DataSource = null;
            if (WorkspaceEventsBox.SelectedValue is long EventID)
            {
                List<MarketSnapshot> Snapshots = WorkspaceDatabase[EventID];

                WorkspaceRunnerBox.DataSource = Snapshots.Select(x => x.Runner).Distinct().ToList();
                WorkspaceMarketBox.DataSource = Snapshots.Select(x => x.Market).Distinct().ToList();

                BindingListView<MarketSnapshot> View = new BindingListView<MarketSnapshot>(Snapshots);
                WorkspaceEventSnapshotsView.DataSource = View;
                WorkspaceEventSnapshotsView.Columns["MatchID"].Visible = false; // potential HACK
                WorkspaceEventSnapshotsView.Columns["Name"].Visible = false;
            }
        }


        private void ImportedEventsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateWorkspaceEventSnapshotsView();
        }

        private void FilterEventSnapshotsView(object sender, EventArgs e)
        {
            ImportedEventSnapshotsView.CurrentCell = null;
            foreach (DataGridViewRow Row in ImportedEventSnapshotsView.Rows)
            {
                if (Row.Cells[2].Value.ToString() == ImportedRunnerFilterBox.SelectedItem.ToString() && Row.Cells[4].Value.ToString() == ImportedMarketFilterBox.SelectedItem.ToString())
                {
                    Row.Visible = true;
                }
                else
                {
                    Row.Visible = false;
                }
            }
        }

        private void WorkspaceEventsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateWorkspaceEventSnapshotsView();
        }

        private void ToWorkspaceButton_Click(object sender, EventArgs e)
        {
            if (ImportedEventsBox.SelectedValue is long EventID)
            {
                if (!(WorkspaceDatabase.ContainsKey(EventID)))
                {
                    WorkspaceDatabase[EventID] = new List<MarketSnapshot>();
                }
                WorkspaceDatabase[EventID] = WorkspaceDatabase[EventID].Union(ImportedDatabase[EventID]).ToList();
            }
         UpdateWorkspaceEventsBox();
        }

        private void ImportOriginalDatabaseButton_Click(object sender, EventArgs e)
        {
            WorkspaceDatabase = OriginalDatabase;
            UpdateWorkspaceEventsBox();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearImportedButton_Click(object sender, EventArgs e)
        {
            ImportedDatabase.Clear();
            UpdateImportedEventsBox();
        }

        private void ClearWorkspaceButton_Click(object sender, EventArgs e)
        {
            WorkspaceDatabase.Clear();
            UpdateWorkspaceEventsBox();
        }

        private void ToImportedButton_Click(object sender, EventArgs e)
        {
            if (WorkspaceEventsBox.SelectedValue is long EventID)
            {
                if (!(ImportedDatabase.ContainsKey(EventID)))
                {
                    ImportedDatabase[EventID] = new List<MarketSnapshot>();
                }
                ImportedDatabase[EventID] = ImportedDatabase[EventID].Union(WorkspaceDatabase[EventID]).ToList();
            }

            UpdateImportedEventsBox();
        }

        private void ExportToFileButton_Click(object sender, EventArgs e)
        {
            FileSaveDialog.InitialDirectory = Directory.GetCurrentDirectory();
            if (FileSaveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    JsonFileSerializer.SerializeSnapshotsToJson(ImportedDatabase, FileSaveDialog.OpenFile());
                }
                catch (Exception Ex)
                {
                    if (Ex is JsonSerializationException || Ex is JsonReaderException)
                    {
                        GUIHelper.ThrowWarning("File error", "Serialization failed.");
                    }
                }
            }
        }
    }
}
