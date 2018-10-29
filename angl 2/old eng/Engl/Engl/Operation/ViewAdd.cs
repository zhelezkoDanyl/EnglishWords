using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engl.DataBase;
using Engl.ENUMS;
using System.Windows;
using System.Windows.Controls;


namespace Engl.Operation
{
 
   public class ViewModelAdd 
    {
        Addwin ADD;
        List<ComboBox> LC;
        List<TextBox> LTB;

        // CONSTRUCTOR
        public ViewModelAdd(Addwin ADDwin)
        {
            
            ADD = ADDwin;
           
             ADD.MOUSE += ADD_MOUSE;
            ADD.addclick += ADD_addclick;
            ADD.Delete += ADD_Delete;
            ADD.update += ADD_update;
            ADD.SelectPart += ADD_SelectPart;
            ADD.clear += ADD_clear;
            ADD.Ok1 += ADD_Ok1;
            ADD.ChekFilytr += ADD_ChekFilytr;
            ADD.Key += ADD_EnKey;

            MethodList();
        }
        private void MethodList()
        {
            LTB = new List<TextBox>();
            LC = new List<ComboBox>();
            LC.Add(ADD.PartOfSpeechCOM);
            LC.Add(ADD.PodPunk);
            LC.Add(ADD.topic);
            
            LTB.Add(ADD.En);
            LTB.Add(ADD.Ru);
        }
     

        private void ADD_EnKey(object sender, EventArgs e)
        {
            if(ADD.FindOfFiltr.IsChecked == true)
            {
                ADD_ChekFilytr(sender, e);
            }
            
           
        }

        private void ADD_ChekFilytr(object sender, EventArgs e)
        {
            ADD.data.SelectedItem = null;
            bool ch;
            if(ADD.FindOfFiltr.IsChecked == true) { ch = true; }
            else { ch = false; }
        ADD.data.ItemsSource  =    SuportMethodAdd.FilytrChek(ch, DataBaseWithMethod.GetListWord, LC, LTB);
           
            
            
        }

     

        private void ADD_Ok1(object sender, EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы  хотите закрыть  окно ?", "Close", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {

                ADD.Close();
            }

                
        }

        private void ADD_clear(object sender, EventArgs e)
        {
           
            MessageBoxResult result = MessageBox.Show("Вы хотите стереть все данные в ячейках ?", "Clear", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                ADD.id.Text = null;
                ADD.En.Text = null;
                ADD.Ru.Text = null;
                ADD.EnSinon.Text = null;
                ADD.RuSinon.Text = null;
                ADD.Form2.Text = null;
                ADD.form3.Text = null;
                ADD.PartOfSpeechCOM.SelectedIndex = 0;
                ADD.PodPunk.SelectedItem = null;
              foreach(var t in ADD.topic.Items)
                {
                    if(t is CheckBox)
                    {
                      var tt =   t as CheckBox;
                        tt.IsChecked = false;

                    }
                }
            }

             
            
        
        }

        private void ADD_SelectPart(object sender, EventArgs e)
        {
            //DataBaseWithMethod.PartOfSpechtype = ADD.myFirstControl1.Data;
            //ADD.PodPunk.ItemsSource = ViewModel.PodTypeProperty;
            //System.Windows.MessageBox.Show(DataBaseWithMethod.PartOfSpechtype.ToString() + " " +ADD.myFirstControl1.Data.ToString());
            //ADD.PodPunk.SelectedIndex = 1;
            MethodSlectPodPunkt();
            ADD.PodPunk.SelectedIndex = 1;

        }

        private void ADD_update(object sender, EventArgs e)
        {     
            if (ADD.id.Text == "" || ADD.id.Text == null)
            {
                MessageBox.Show("не выбран Item для изменений");
            }
            else
            {

                MessageBoxResult result = MessageBox.Show("Вы ходите сохранить изменение ?", "Update", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {



                        // изминения на прямую произойдут без проверки
                        //var emp =  ADD.data.SelectedItem as Word
                        var emp = new Word();

                        emp.EN = ADD.En.Text;
                        emp.Ru = ADD.Ru.Text;
                        emp.SynonymsEn = ADD.EnSinon.Text;
                        emp.SynonymsRu = ADD.RuSinon.Text;
                        emp.PastSimiple = ADD.Form2.Text;
                        emp.PastPart = ADD.form3.Text;
                        emp.Tema = ViewModel.TopicStringMethod(ADD.topic);
                        emp.NumberPart = ADD.PartOfSpeechCOM.SelectedIndex;
                        emp.NumberKind = ADD.PodPunk.SelectedIndex;

                        ViewModel vm = new ViewModel();
                        string strtext;
                        if (vm.ProverkaVolidate(emp, out strtext, 1))
                        {
                            var empTest = ADD.data.SelectedItem as Word;
                            empTest.EN = ADD.En.Text;
                            empTest.Ru = ADD.Ru.Text;
                            empTest.SynonymsEn = ADD.EnSinon.Text;
                            empTest.SynonymsRu = ADD.RuSinon.Text;
                            empTest.PastSimiple = ADD.Form2.Text;
                            empTest.PastPart = ADD.form3.Text;
                            empTest.Tema = ViewModel.TopicStringMethod(ADD.topic);
                            empTest.NumberPart = ADD.PartOfSpeechCOM.SelectedIndex;
                            empTest.NumberKind = ADD.PodPunk.SelectedIndex;
                            //DataBaseWithMethod.UpDate();
                        }
                        else
                        {

                            MessageBox.Show(strtext);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Проблема при изменении! " + ex.ToString());
                    }

                }
                else
                {
                    //DataBaseWithMethod.Cancel();
                }
                ADD.data.ItemsSource = CreateClassWords.MyWords.wordList.ToList();
              
            }
       
         
        }

        private void ADD_Delete(object sender, EventArgs e)
        {
            if (ADD.data.SelectedItem != null)
            {



                MessageBoxResult result = MessageBox.Show("Вы ходите удалить ?", "DELTE", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var emp = ADD.data.SelectedItem as Word;

                    //  string word = emp.EN;



                    DataBaseWithMethod.del(emp);
                }




                ADD.data.ItemsSource = DataBaseWithMethod.GetListWord;
            }
            else
            {
                MessageBox.Show("Не выбран Item для удаления");
            }
        }

        private void ADD_addclick(object sender, EventArgs e)
        {
           
                var emp = new Engl.DataBase.Word();

                emp.EN = ADD.En.Text;
                emp.Ru = ADD.Ru.Text;
                emp.SynonymsEn = ADD.EnSinon.Text;
                emp.SynonymsRu = ADD.RuSinon.Text;
                emp.PastSimiple = ADD.Form2.Text;
                emp.PastPart = ADD.form3.Text;
                emp.NumberPart = ADD.PartOfSpeechCOM.SelectedIndex;
                emp.NumberKind = ADD.PodPunk.SelectedIndex;
                emp.Tema = ViewModel.TopicStringMethod(ADD.topic);

            
            string TextWhithResult;

            ViewModel vm = new ViewModel();
          if(  vm.ProverkaVolidate(emp, out TextWhithResult,0))
            {
                MessageBoxResult result = MessageBox.Show("Добавить в библиотеку следуещее слово ? " + emp.EN + " - " + emp.Ru, "ADD", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {


                        DataBaseWithMethod.add(emp);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }



                }
              
            }
            else
            {
                MessageBox.Show(TextWhithResult);
            }




            ADD.data.ItemsSource = DataBaseWithMethod.GetListWord;
        }

        private void ADD_MOUSE(object sender, EventArgs e)
        {
            
        
      
            if (ADD.data.SelectedItem == null)
            {
                //  SystemColors.InactiveSelectionHighlightBrush

                //try
                //{

                //    System.Windows.MessageBox.Show("Не выбрано поле - SelectRow = null");
                //    return;
                //}
                //catch (Exception ex)
                //{
                //    System.Windows.MessageBox.Show(ex.ToString());
                //    return;
                //}

            }
            else
            {
                Word selectedRow = ADD.data.SelectedItem as Word;

                ADD.id.Text = selectedRow.id.ToString();
                ADD.En.Text = selectedRow.EN;
                ADD.Ru.Text = selectedRow.Ru;
                ADD.EnSinon.Text = selectedRow.SynonymsEn;
                ADD.RuSinon.Text = selectedRow.SynonymsRu;
                ADD.Form2.Text = selectedRow.PastSimiple;
                ADD.form3.Text = selectedRow.PastPart;
                ADD.PartOfSpeechCOM.SelectedIndex = selectedRow.NumberPart;
                MethodSlectPodPunkt();
                ADD.PodPunk.SelectedIndex = selectedRow.NumberKind;
                ADD.topic = ViewModel.RegularTopicComb(ADD.topic, selectedRow.Tema);

            }

        }

        private void MethodSlectPodPunkt()
        {
            DataBaseWithMethod.PartOfSpechtype = ADD.myFirstControl1.Data;
            ADD.PodPunk.ItemsSource = ViewModel.PodTypeProperty;
            //System.Windows.MessageBox.Show(DataBaseWithMethod.PartOfSpechtype.ToString() + " " + ADD.myFirstControl1.Data.ToString());
        
        }
 
     
    }
}
