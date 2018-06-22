using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Engl.Kateroris
{
    class SubViewModal
    {
        Subjects sub;
        ModelSub ms = new ModelSub();
        public SubViewModal(Subjects subV)
        {
            sub = subV;
            sub.Addclick += Sub_Addclick;
            sub.pickItems += Sub_pickItems;
            sub.Editclick += Sub_Editclick;
            sub.DelTem += Sub_DelTem;
            sub.ButonOk += Sub_ButonOk;
        }

        private void Sub_DelTem(object sender, EventArgs e)
        {
            try
            {
                if (sub.listBox.SelectedItem != null)
                {
                    MessageBoxResult res = MessageBox.Show("Хотите удалить тему - " + sub.listBox.SelectedItem+ " ? ", "Del", MessageBoxButton.YesNo);
                    if (res == MessageBoxResult.Yes)
                    {
                       ms.Delet(sub.listBox.SelectedItem.ToString());
                        sub.listBox.ItemsSource = DependencyPropertySub.otherTems;
                        Addwin ad = DependencyPropertySub.WindAdd;
                        ad.topic.ItemsSource = ENUMS.AzzA.Tema;

                        sub.textBox.Text = null;
                    }

                }
                else
                {
                    System.Windows.MessageBox.Show("Проверте выбрана ли тема которую вы хотите удалить!");
                }
            }
            catch (Exception ee)
            {
                System.Windows.MessageBox.Show("Item  не выбран из списка доступных тем! " + e.ToString());
            }
        }

        private void Sub_ButonOk(object sender, EventArgs e)
        {
            sub.Close();
        }

        private void Sub_Editclick(object sender, EventArgs e)
        {
            try
            {
                if(sub.listBox.SelectedItem != null && sub.textBox.Text !=null && sub.textBox.Text!="")
                {
                    MessageBoxResult res = MessageBox.Show("Хотите изменить тему - " + sub.listBox.SelectedItem + "  на  -> " + sub.textBox.Text + " ? ","Edit" , MessageBoxButton.YesNo);
                    if(res == MessageBoxResult.Yes)
                    {
                        ms.EditTema(sub.listBox.SelectedItem.ToString(), sub.textBox.Text);
                        sub.listBox.ItemsSource = DependencyPropertySub.otherTems;
                        Addwin ad = DependencyPropertySub.WindAdd;
                        ad.topic.ItemsSource = ENUMS.AzzA.Tema;

                        sub.textBox.Text = null;
                    }
                
                }
                else
                {
                    System.Windows.MessageBox.Show("Проверте выбрана ли тема которую вы хотите изменить, и наличие текста в ТекстБоксе!");
                }
            }
            catch(Exception ee)
            {
                System.Windows.MessageBox.Show("Item  не выбран из списка доступных тем! " + e.ToString());
            }
        }

        private void Sub_pickItems(object sender, EventArgs e)
        {
            if(sub.listBox.SelectedItem !=null)
            sub.textBox.Text = sub.listBox.SelectedItem.ToString();
        }

        private void Sub_Addclick(object sender, EventArgs e)
        {
            if(sub.textBox.Text !=null && sub.textBox.Text!="")
            {
                System.Windows.MessageBoxResult res = System.Windows.MessageBox.Show("Хотите дабавить новую тему > " + sub.textBox.Text + " < ?","Add Subj", System.Windows.MessageBoxButton.YesNo);
                if(res == MessageBoxResult.Yes)
                {
                    try
                    {
                        ms.addTem(sub.textBox.Text);
                        sub.listBox.ItemsSource = DependencyPropertySub.otherTems;
                        Addwin ad = DependencyPropertySub.WindAdd;
                        ad.topic.ItemsSource = ENUMS.AzzA.Tema;
                        sub.textBox.Text = null;
                    }
                    catch(Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                   
                }
             
            }
            else
            {
                MessageBox.Show("Вы не можете добавить в тему пустое значение!");

            }
        }
    }
}
