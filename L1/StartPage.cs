using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    public class StartPage : ContentPage
    {
        public StartPage()
        {
            Label label1 = new Label()
            {
                Text = "Первая метка",
                TextColor = Colors.Red
            };
            Label label2 = new Label()
            {
                Text = "Вторая метка",
                TextColor = Colors.Blue
            };
            Label label3 = new Label()
            {
                Text = "Третья метка",
                TextColor = Colors.Green
            };

            StackLayout stackLayout = new StackLayout()
            {
                Children = { label1, label2, label3 }
            };
            stackLayout.Spacing = 5;
            stackLayout.Orientation = StackOrientation.Horizontal;
            Content = stackLayout;
        }
    }
}
