using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ReactiveUI;
using System.Reactive;
using Kanban.Models;


namespace Kanban.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Task>[] Tasks { get; set; }
        public MainWindowViewModel()
        {
            Tasks = new ObservableCollection<Task>[3] { new ObservableCollection<Task> { new Task("САОД","пересдача","Kanban/Assets/sticky.ico"),
                                                                                         new Task("ТерВер","ДЗ","Kanban/Assets/sticky.ico")},
                                                        new ObservableCollection<Task> {  new Task("ВычМат","ДЗ", "Kanban/Assets/sticky.ico") },
                                                        new ObservableCollection<Task> { new Task("СГМА","РГР3","Kanban/Assets/sticky.ico"),
                                                                                         new Task("ЭЭС","6 лаба","Kanban/Assets/sticky.ico")}
            };

            Exit = ReactiveCommand.Create(() => Environment.Exit(0));
            NewKanban = ReactiveCommand.Create(() => ClearTasks());
            Add = ReactiveCommand.Create<string, int>((column) => AddTask(column));
        }

        public ReactiveCommand<Unit, Unit> Exit { get; }
        public ReactiveCommand<Unit, int> NewKanban { get; }
        public ReactiveCommand<string, int> Add { get; }

        public int ClearTasks()
        {
            Tasks[0].Clear();
            Tasks[1].Clear();
            Tasks[2].Clear();
            return 0;
        }
        private int AddTask(string column)
        {
            int ind = int.Parse(column);
            Tasks[ind].Add(new Task("", "", "Kanban/Assets/avalonia-logo.ico"));
            return 0;
        }

    }


}