   M S B A M L   `   `   `  ���� I  EFindInFile_Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FindInFile.Wpf.ViewsFindInFile.Wpf.Views  E'clr-namespace:FindInFile.Wpf.ViewModelsFindInFile.Wpf.ViewModels  '    !FindInFile.Wpf.Views.FindTextView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     4local"clr-namespace:FindInFile.Wpf.Views     >
viewModels'clr-namespace:FindInFile.Wpf.ViewModels        MaterialDesignBody#���     MaterialDesignPaper#���  $��Regular"�$��13(�$X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�  � 	Resources  1   +FindInFile.Wpf.ViewModels.FindTextViewModel  findTextViewModel��%   &	         .��� 
������� � RowDefinitions �� $	��150 ��� $��3* ��� $��25 � � ColumnDefinitions �� $��* ��� $��* �.+��� $��
Find What:��$��	5,5,2.5,5q�$��1q�.����  �� Orientation$ Vertical=�$��5q�.+�]� .+��� -    ��Name$ queryTextBox��$��20������ *	QueryText+�� $ 
Horizontal=�$
��0,10q�.+��� -    ��Name$ 
findButton�����	#FF9FF967���� *FindClicked+.���� $
��FIND��$
��15,5q�$
��Bold"����	#FF198005�  �� $��* ��� $��* � �� $��* ��� $��* �.+��� -    ��Name$ recursiveCheckBox��$��0��$��0��$��	Recursive��$��	10,0,10,0q� d� 	IsChecked �� *RecursiveChecked+�� -   $ fuzzySearchCheckBox��$��0��$��1��$��Fuzzy Search��$��	10,5,10,0q� �� *FuzzySearchChecked+�� -   $ matchCaseCheckBox��$��1��$��0��$��
Match Case��$��0,0,0,0q� �� *MatchCaseChecked+�� -   $ copyToClipboardCheckBox��$��1��$��1��$��Copy Search To Clipboard��$��0,5,0,0q� �� *CopyToClipboardChecked+]� $��1��$��	2.5,5,5,5q�.+��� $��Folder Path��$	��Top=�.��]� .+��� -   $ browseFolderPathButton��$��Right=�$��5,0,0,0q����� *BrowseClick+.���� $��Browse��$	��5,0q��� -   $ rootPathTextBox��$��20������ *RootPathText+�� $��Filter��.��]� $��5q�.+��� -	   $ advancedFilterButton��$��Right=�$��5,0,0,0q����� *AdvancedClick+.���� $��Advanced��$	��5,0q��� -
   $ filterTextBox��$��20������ *
FilterText+]� $��1��$��2��$��5q�.+��� -    ��Name$ resultsListView������ *	MatchList+    LineMatchtemplate	 ��Name��%�   &	       �� .R��� $	 LineMatchStackPanel��$��0������ .R��� $ 
Horizontal=����� .R��� ���� *
ItemName+
 �� View
 �� .P��� $��	File Path�� �� Width$
 AUTO�� �� DisplayMemberBinding �� *ShortenedPath+�� $��Line Number��$
 AUTO�� �� *
LineNumber+�� $��Find Results��$
 AUTO�� �� *MatchedLine+�� $��Test Column�� �� CellTemplate# [ $
 AUTO��]� -    ]�Name$ statusBarDockPanel��$��2��$��2��.+��� $��Bottom=�.@��� -   $��statusBarTextBlock��$	��5,0q����� *StatusBarText+���� *StatusBarTextColor+�� o� .@�m� -   $��DebuggerConsoleStrip������ $ 
Horizontal=�.+��� -   $��DubbugerButton��$;��5/FindInFile_Wpf;component/Resources/Debugger-Icon.png���� $��
Debug Data��.@�m� $	��...��