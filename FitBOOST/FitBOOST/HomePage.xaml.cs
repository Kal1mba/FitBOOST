using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitBOOST
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        DataBaseConnection dataBase = new DataBaseConnection();
        ObservableCollection<Muscles> muscles = new ObservableCollection<Muscles>();
        List<Trainers> trainersList = new List<Trainers>();
        
        

        Muscles selectedMuscles;
        Trainers selectedTrainer;
        public HomePage()
        {
            InitializeComponent();
            //welcomeBackgroundImage.Source = ImageSource.FromResource("FitBOOST.welcomeBackground.png");
            //welcomeBackgroundImage.Aspect = Aspect.AspectFill;

            AddedTrainers();

            TrainersPicker.ItemsSource = trainersList;
            TrainersPicker.SelectedIndex = 0;

            AddedMusclar();

            MusclesCarouselView.ItemsSource = muscles;
            MusclesCarouselView.CurrentItem = muscles.FirstOrDefault();


            //RefreshData(selectedTrainer.IdName, selectedMuscles.IdName);
        }
       

        private void AddedTrainers()
        {

            trainersList.Add(new Trainers
            {
                IdName = "*",
                Name = "Все"
            }); trainersList.Add(new Trainers
            {
                IdName = "Stretches",
                Name = "Вытягивания"
            }); trainersList.Add(new Trainers
            {
                IdName = "Bodyweight",
                Name = "Упражнения с массой тела"
            }); trainersList.Add(new Trainers
            {
                IdName = "Barbell",
                Name = "Штанга"
            }); trainersList.Add(new Trainers
            {
                IdName = "Cables",
                Name = "Тросовый тренажер"
            }); trainersList.Add(new Trainers
            {
                IdName = "Dumbbells",
                Name = "Гантели"
            }); trainersList.Add(new Trainers
            {
                IdName = "Kettlebells",
                Name = "Гири"
            }); trainersList.Add(new Trainers
            {
                IdName = "Band",
                Name = "Гимнастическая резинка"
            });
        }

        void AddedMusclar()
        {
            muscles = new ObservableCollection<Muscles>
            {
                new Muscles{MuscleCategory = Muscles.Category.Core, IdName = "Abdominals", Name = "Мышцы брюшного пресса", Image="Abdominals.png"},
                new Muscles{MuscleCategory = Muscles.Category.Arms, IdName = "Biceps", Name = "Бицепсы", Image="Biceps.png"},
                new Muscles{MuscleCategory = Muscles.Category.Legs, IdName = "Calves", Name = "Икры ног", Image="Calves.png"},
                new Muscles{MuscleCategory = Muscles.Category.Core, IdName = "Chest", Name = "Грудь", Image="Chest.png"},
                new Muscles{MuscleCategory = Muscles.Category.Arms, IdName = "Forearms", Name = "Предплечья", Image="Forearms.png"},
                new Muscles{MuscleCategory = Muscles.Category.Core, IdName = "Glutes", Name = "Ягодицы", Image="Glutes.png"},
                new Muscles{MuscleCategory = Muscles.Category.Legs, IdName = "Hamstrings", Name = "Подколенные сухожилия", Image="Hamstrings.png"},
                new Muscles{MuscleCategory = Muscles.Category.Core, IdName = "Lats", Name = "Широчайшая мышца спины", Image="Lats.png"},
                new Muscles{MuscleCategory = Muscles.Category.Core, IdName = "Lower back", Name = "Поясница", Image="LowerBack.png"},
                new Muscles{MuscleCategory = Muscles.Category.Core, IdName = "Obliques", Name = "Косые мышцы", Image="Obliques.png"},
                new Muscles{MuscleCategory = Muscles.Category.Legs, IdName = "Quads", Name = "Квадрицепсы", Image="Quads.png"},
                new Muscles{MuscleCategory = Muscles.Category.Arms, IdName = "Shoulders", Name = "Плечи", Image="Shoulders.png"},
                new Muscles{MuscleCategory = Muscles.Category.Core, IdName = "Traps", Name = "Трапециевидная мышца", Image="Traps.png"},
                new Muscles{MuscleCategory = Muscles.Category.Core, IdName = "Traps_mid_back", Name = "Нижняя трапециевидная мышца", Image="Traps_mid_back.png"},
                new Muscles{MuscleCategory = Muscles.Category.Arms, IdName = "Triceps", Name = "Трицепсы", Image="Triceps.png"}
            };
        }

        
        private void MusclesCarouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            selectedMuscles = e.CurrentItem as Muscles;
            selectedTrainer = (Trainers)TrainersPicker.SelectedItem;
            RefreshData(selectedTrainer.IdName, selectedMuscles.IdName);
        }

        void TrainersPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTrainer = (Trainers)TrainersPicker.SelectedItem;
            try
            {
                RefreshData(selectedTrainer.IdName, selectedMuscles.IdName);
            }
            catch
            {
                RefreshData(selectedTrainer.IdName, "Abdominals");
            }
        }

        private void RefreshData(string TrainersType, string MuscleType)
        {
            myCollectionView.ItemsSource = null;
            try
            {
                string queryString;
                if (TrainersType == "*")
                {
                    queryString = $"select ID, ExerciseName, VideoInstructions from Trainers2 where MuscleType = '{MuscleType}'";

                }
                else
                {
                    queryString = $"select ID, ExerciseName, VideoInstructions from Trainers2 where MuscleType = '{MuscleType}' and TrainersType ='{TrainersType}'";
                }

                dataBase.openConnection();
                SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());


                List<PreviewExerciseModel> exerciseModels = new List<PreviewExerciseModel>();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PreviewExerciseModel model = new PreviewExerciseModel();
                        model.Id = reader.GetInt32(0);
                        model.ExerciseName = reader.GetString(1);
                        var htmlSource = new HtmlWebViewSource();
                        Uri uri = new Uri(reader.GetString(2));
                        model.VideoSource = uri;

                        exerciseModels.Add(model);
                    }
                }
                myCollectionView.ItemsSource = exerciseModels;

                
            }
            catch(Exception ex)
            {
                var massage = ex.Message;
            }
        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
            var grid = (Grid)sender;
             // Приводим sender к типу Grid
            var idLabel = grid.FindByName<Label>("IdLabel"); // Ищем элемент IdLabel внутри Grid


            if (idLabel != null)
            {
                string id = idLabel.Text; // Получаем значение текста из IdLabel

                // Дальше можно выполнять нужные действия с полученным id
                // Например, передать его в другую страницу через навигацию
                await Navigation.PushModalAsync(new GetExerciseInstructionsPage(id));
            }
        }
    }
}