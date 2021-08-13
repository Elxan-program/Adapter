using Adapter.Adapter;
using Adapter.Command;
using Adapter.Model;
using Adapter.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Adapter.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnpropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public ObservableCollection<User> Users { get; set; }

        private User _user;

        public User User { get { return _user; } set { _user = value; OnpropertyChanged(); } }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand ViewCommand { get; set; }

        public MainWindow MainWindow { get; set; }

        public MainViewModel()
        {
            Xml XML_File = new Xml();
            Json JSON_File = new Json();


            if (XML_File.User_List == null)
            {
                XML_File.User_List = new ObservableCollection<User>();
            }

            if (JSON_File.User_List == null)
            {
                JSON_File.User_List = new ObservableCollection<User>();
            }

            User = new User
            {
                Name = "Name",
                Surename = "Surename",
                Email = "Email",
            };

            SaveCommand = new RelayCommand((e) =>
            {
                IAdapter adapter;

                if (Hepler.MainWindow.Xml_Rad_Btn.IsChecked == true)
                {
                    try
                    {
                        MessageBox.Show("XML File Is Ready!");
                        if (XML_File.User_List == null)
                        {
                            XML_File.User_List.Add(new User()
                            {
                                Name = Hepler.MainWindow.Name_Txt_Box.Text,
                                Surename = Hepler.MainWindow.Surname_Txt_Box.Text,
                                Email = Hepler.MainWindow.Gmail_Txt_Box.Text,
                            });

                            XML_File.User_List.RemoveAt(0);

                            adapter = new XmlAdapter(XML_File);

                            AppL application = new AppL(adapter);

                            application.Start();
                        }

                        if (XML_File.User_List != null)
                        {
                            XML_File.User_List.Add(new User()
                            {
                                Name = Hepler.MainWindow.Name_Txt_Box.Text,
                                Surename = Hepler.MainWindow.Surname_Txt_Box.Text,
                                Email = Hepler.MainWindow.Gmail_Txt_Box.Text,
                            });

                            adapter = new XmlAdapter(XML_File);

                            AppL application = new AppL(adapter);

                            application.Start();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                if (Hepler.MainWindow.Json_Rad_Btn.IsChecked == true)
                {
                    try
                    {
                        MessageBox.Show("JSON File Is Ready!");
                        if (JSON_File.User_List == null)
                        {
                            JSON_File.User_List.Add(new User()
                            {
                                Name = Hepler.MainWindow.Name_Txt_Box.Text,
                                Surename = Hepler.MainWindow.Surname_Txt_Box.Text,
                                Email = Hepler.MainWindow.Gmail_Txt_Box.Text,
                            });

                            JSON_File.User_List.RemoveAt(0);

                            adapter = new JsonAdapter(JSON_File);

                            AppL application = new AppL(adapter);

                            application.Start();
                        }

                        if (JSON_File.User_List != null)
                        {
                            JSON_File.User_List.Add(new User()
                            {
                                Name = Hepler.MainWindow.Name_Txt_Box.Text,
                                Surename = Hepler.MainWindow.Surname_Txt_Box.Text,
                                Email = Hepler.MainWindow.Gmail_Txt_Box.Text,
                            });

                            adapter = new JsonAdapter(JSON_File);

                            AppL application = new AppL(adapter);

                            application.Start();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            });
        }
    }
}
