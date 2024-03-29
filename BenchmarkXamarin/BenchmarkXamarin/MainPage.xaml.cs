﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkXamarin.Runners;

namespace BenchmarkXamarin
{
    [DesignTimeVisible(false)]
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Start();
        }

        private async Task Start()
        {
            SetIsRunning(true);
            try
            {
                var logger = new AccumulationLogger();
                await Task.Run(() =>
                {
                    var summary = BenchmarkRunner.Run<EmptyBenchmarks>();

                    MarkdownExporter.Console.ExportToLog(summary, logger);
                    ConclusionHelper.Print(
                        logger,
                        summary.BenchmarksCases
                               .SelectMany(benchmark => benchmark.Config.GetCompositeAnalyser().Analyse(summary))
                               .Distinct()
                               .ToList());
                });
                SetSummary(logger.GetLog());
            }
            catch (Exception exc)
            {
                await DisplayAlert("Error", exc.Message, "Ok");
            }
            finally
            {
                SetIsRunning(false);
            }
        }

        private void SetIsRunning(bool isRunning)
        {
            Indicator.IsRunning = isRunning;
            Run.IsVisible = Summary.IsVisible = !isRunning;
        }

        private void SetSummary(string text)
        {
            Summary.Text = text;
            var size = Summary.Measure(double.MaxValue, double.MaxValue).Request;
            Summary.WidthRequest = size.Width;
            Summary.HeightRequest = size.Height;
        }
    }
}
