using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CurrencyTrader.AdoNet;

namespace CurrencyTrader.Gui
{
    public partial class Form1 : Form
    {
        private TradeProcessor tradeProcessor;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var tradeStream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("SingleResponsibilityPrinciple.trades.txt");
            var tradeUrl = "http://faculty.css.edu/tgibbons/trades100.txt";

            var logger = new ConsoleLogger();
            //var logger = new GuiLogger(lbStatus.Items);

            //var tradeDataProvider = new StreamTradeDataProvider(tradeStream);
            var tradeDataProvider = new AdjustTradeDataProvider(tradeUrl);

            var tradeValidator = new SimpleTradeValidator(logger);
            var tradeMapper = new SimpleTradeMapper();
            var tradeParser = new SimpleTradeParser(tradeValidator, tradeMapper);

            var tradeStorage = new AdoNetTradeStorage(logger);
            tradeProcessor = new TradeProcessor(tradeDataProvider, tradeParser, tradeStorage);
        }

        private void btnReadTrades_Click(object sender, EventArgs e)
        {
            var lines = tradeProcessor.ReadTrades();
            foreach (var line in lines) lbTradeLines.Items.Add(line);
            txtStoreStatus.Text = "Trades NOT stored in database yet.";
        }

        private void btnParseTrades_Click(object sender, EventArgs e)
        {
            var trades = tradeProcessor.ParseTrades();
            txtNumTrades.Text = trades.Count().ToString();
        }

        private void btnStoreTrades_Click(object sender, EventArgs e)
        {
            tradeProcessor.StoreTrades();
            txtStoreStatus.Text = "Trades written to database.";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}