using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitBOOST
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetExerciseInstructionsPage : ContentPage
    {
        DataBaseConnection dataBase = new DataBaseConnection();
        public GetExerciseInstructionsPage()
        {
            InitializeComponent();
        }
        public GetExerciseInstructionsPage(string TrainersId)
        {
            InitializeComponent();



            VideoInstructionView.ItemsSource = null;
            try
            {
                string queryString = $"select * from Trainers2 where ID = {TrainersId}";

                SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

                dataBase.openConnection();
                SqlDataReader reader = command.ExecuteReader();
                ObservableCollection<VideoInstructionsSource> videoModel = new ObservableCollection<VideoInstructionsSource>();

                while (reader.Read())
                {
                    var model = new DetailedInstructionsModel();
                    
                    PageExerciseName.Text = reader.GetString(1);
                    PageDifficulty.Text = reader.GetString(2);
                    PageMuscleType.Text = reader.GetString(8);
                    PageTrainersType.Text = reader.GetString(9);
                    PageTextInstructions.Text = reader.GetString(3);

                    videoModel.Add(new VideoInstructionsSource
                    {
                        VideoSource = reader.GetString(4)
                    });
                    videoModel.Add(new VideoInstructionsSource
                    {
                        VideoSource = reader.GetString(5)
                    });
                }
                VideoInstructionView.ItemsSource = videoModel;
                dataBase.closeConnection();
            }
            catch(Exception ex)
            {
                DisplayAlert("error", ex.Message,"Ok");
            }
        }


        private async void CloseModal_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        protected override bool OnBackButtonPressed()
        {
            return true; 
        }
    }
}