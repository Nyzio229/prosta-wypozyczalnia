   M S B A M L   `   `   `  ���� H  DRentCarClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RentCarClientRentCarClient      RentCarClient.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:RentCarClient       � Title$   Wypożyczalnia Samochodowa��$	��450��$	��800��.���  � ColumnDefinitions �� $	��41* ��� $	��39* �.+�� $��10,10,10,10q� � RowDefinitions �� $	��75* ��� $
��145* ��� $	��98* �.+��� -    ��Name$ 
rentButton��$��Wypozycz��$��Center=�$	��Top=�$��39��$	��312��$��0,24,0,0q�$��22(�$
��Bold"��� -    ��Name$ rentBox��$��Center=�$	��Top=�$��20��$	��246��$��1��$��0,22,0,0q�$��18(����� .R��� �� ��� *Make+ �� ��� *Model+�� -   $ refreshButton��$��Odswiez��$��Center=�$��Center=�$��72��$	��350��$��2��$��22(�$
��Bold"�� $��56,183,206,164q�$y�Hidden=� �� $	��25* ��� $	��25* � �� $	��29* ��� $
��118* �.+�(  "System.Windows.Controls.DatePicker  -     Name$ fromDate��	fDate��$��Center=�$��Center=�$��24��$	��104��$��1��  -   $ toDate��	tDate��$��Center=�$��Center=�$��24��$	��104��$��1��$��1���� $	��Od:��$��Center=�$��Center=�$��26��$��30���� $	��Do:��$��Center=�$��1��$��Center=�$��26��$��28��� $��10,10,10,10q�$��1�� �� $
��159* ��� $
��149* ��� $
��106* �.+��� $��Center=�$
��Wrap=�$��Wypozyczone samochody:��{�.  $��67��$	��276��$��Center=� �� 
LineHeight$ 10��$��20(�$
��Bold"� �� TextAlignment$ Center=��� -    ��Name$ 
rentedList��$��Center=�$	��330��$	��129��$��Center=�$��1��$��18(����� .R��� �� ��� *Make+�� $� ���� ��� *Model+�� -   $ cancelRentBt��$$��Zwróć samochód przed czasem��$��Center=�$��0,10,0,0q�$	��Top=�$	��330��$��74��$��2��$��20(�$
��Bold"�