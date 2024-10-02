namespace ml_classifier
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public string search_term = string.Empty;


        void onChange_search(Object sender, TextChangedEventArgs e)
        {
            search_term = e.NewTextValue;

        }

        public async Task<FileResult> PickAndShow(PickOptions options)
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(options);
                if(result != null)
                {
                    Console.WriteLine(result.FileName);
                    search.Text = result.FullPath;
                return result;
                }
            }catch(Exception ex)
            {

            }
            return null;
        }

        async void SearchFile(object sender, EventArgs e)
        {
            await PickAndShow(PickOptions.Images);
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count+=10;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
