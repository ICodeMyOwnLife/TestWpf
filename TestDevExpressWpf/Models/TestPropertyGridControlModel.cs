using System;
using System.Drawing;
using CB.Model.Common;


namespace TestDevExpressWpf.Models
{
    public class TestPropertyGridControlModel: BindableObject
    {
        #region Fields
        private Color _color = Color.DarkOrchid;private DateTime _date = DateTime.Now;
        private Brush _fill = Brushes.BlueViolet;
        private double _height = 120;
        private string _name = "Special Ellipse";
        private Brush _stroke = Brushes.DarkSlateBlue;
        private double _strokeThickness = 2;
        private double _width = 120;
        #endregion


        #region  Properties & Indexers
        public Color Color
        {
            get { return _color; }
            set { SetProperty(ref _color, value); }
        }

        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        public Brush Fill
        {
            get { return _fill; }
            set { SetProperty(ref _fill, value); }
        }

        public double Height
        {
            get { return _height; }
            set { SetProperty(ref _height, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public Brush Stroke
        {
            get { return _stroke; }
            set { SetProperty(ref _stroke, value); }
        }

        public double StrokeThickness
        {
            get { return _strokeThickness; }
            set { SetProperty(ref _strokeThickness, value); }
        }

        public double Width
        {
            get { return _width; }
            set { SetProperty(ref _width, value); }
        }
        #endregion
    }
}