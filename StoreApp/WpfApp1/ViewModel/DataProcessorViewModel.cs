using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.ViewModel
{
	public class DataProcessorViewModel 
	{
		
		public List<string> mDetectFlag(string pEnterString)
		{

			var date = new List<string>();
			date = pEnterString.Split(';').ToList();
			return date;
		}

		

		//mesajul este construit dupa un protocol
		//se insereaza mesajul primit intr-un observableCollection de tip DataProcessorModel
		public ObservableCollection<DataProcessorModel> mSplit(List<string> pEnterString, ObservableCollection<DataProcessorModel> date)
		{
			//ObservableCollection<DataProcessorModel> date = new ObservableCollection<DataProcessorModel>();
			List<string> listenter = new List<string>();

			List<DataProcessorModel> listdataPrModel = new List<DataProcessorModel>();

			int contor = 0;
			int contor_blocks = 0;
			string createComanda="";
			foreach (string valueUsed in pEnterString)
			{
				if (valueUsed == "...")
				{
					contor = 0;
					

					listenter.Add(createComanda);

					listdataPrModel.Add(new DataProcessorModel
					{
						Id_client = listenter[contor_blocks],
						NumeClient = listenter[contor_blocks + 1],
						NrTelefon = listenter[contor_blocks + 2],
						Adresa = listenter[contor_blocks + 3],
						StagiuComanda = "Waiting",
						PreparetionTime = listenter[contor_blocks + 4],
						Comanda = listenter[contor_blocks + 5],
						NrCrt = contor_blocks / 6 + 1
					});

					contor_blocks += 6;
					createComanda = "";

				}
				else
				{
					if (contor < 5)
					{
						listenter.Add(valueUsed);
						contor++;
					}
					else
					{
						createComanda += valueUsed + "    ";
					}
				}

			}
			
			foreach (var addingelements in listdataPrModel)
			{
				date.Add(addingelements);
			}
			
			return date;
		}
	
		



	}
}
