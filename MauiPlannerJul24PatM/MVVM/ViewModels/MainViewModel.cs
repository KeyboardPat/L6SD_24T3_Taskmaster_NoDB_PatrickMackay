using Kotlin.Properties;
using MauiPlannerJul24PatM.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPlannerJul24PatM.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }
        public MainViewModel()
        {
            FillData();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
        }

        private void Tasks_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void FillData()
        {
            Categories = new ObservableCollection<Category>
            {
                new Category
                {
                    Id = 1,
                    CategoryName = "Name",
                    Color = "#CF14DF"
                },

                new Category
                {
                    Id = 2,
                    CategoryName = "Name",
                    Color = "#df6f14"
                },

                new Category
                {
                    Id = 3,
                    CategoryName = "Name",
                    Color = "#14df80"
                },
            };
            Tasks = new ObservableCollection<MyTask>
            {
                new MyTask
                {
                    TaskName = "Name",
                    Completed = false,
                    CategoryId = 1,
                },

                 new MyTask
                {
                    TaskName = "Name",
                    Completed = false,
                    CategoryId = 1,
                },

                  new MyTask
                {
                    TaskName = "Name",
                    Completed = false,
                    CategoryId = 1,
                }
            };
            UpdateData();
        }

        public void UpdateData()
        {
            foreach (var c in Categories)
            {
                var tasks = from t in Tasks
                            where t.CategoryId == c.Id
                            select t;

                var completed = from t in Tasks
                                where t.Completed == true
                                select t;

                var incomplete = from t in Tasks
                                 where t.Completed == false
                                 select t;

                c.PendingTasks = incomplete.Count();
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
            }

            foreach (var t in Tasks) 
            {
                var catColor = (from c in Categories
                                where c.Id == t.CategoryId
                                select c.Color).FirstOrDefault();
                t.TaskColor = catColor;
            }
    }
    } }
