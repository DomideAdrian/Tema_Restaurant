using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Model;

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

		
		public  List<Curieri> mSplitCurieri(List<string> pEnterString)
		{
			List<Curieri> list = new List<Curieri>();
			int _contor = 0;
			string _Nume="";
			foreach(var value in pEnterString)
			{

				if (_contor == 1)
				{

					list.Add(new Curieri
					{

						NumeCurier = _Nume,
						NumarTelefon = value,
						StagiuComandaCurier = "Waiting",
						Id_comanda = "000000"
					});
					
					_contor = 0;
				}
				else
				{

					_contor = 1;
					_Nume = value;
				}

				
			}



			return list;
		}




		//mesajul este construit dupa un protocol
		//se insereaza mesajul primit intr-un observableCollection de tip DataProcessorModel
		public ObservableCollection<DataProcessorModel> mSplit(List<string> pEnterString, ObservableCollection<DataProcessorModel> date)
		{
		
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
						Id_comanda = listenter[contor_blocks],
						NumeClient = listenter[contor_blocks + 1],
						NrTelefon = listenter[contor_blocks + 2],
						Adresa = listenter[contor_blocks + 3],
						StagiuComanda = "Waiting",
						PreparetionTime = listenter[contor_blocks + 4],
						Comanda = listenter[contor_blocks + 5],
						
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
