# TextEditor
Simple text editor in WPF, C#, MVVM

The code needs refactoring to fully implement MVVM architecture.
TexetEditor has a basic functionalities: saving file, opening file, opening new file, cut, copy, paste,
redo, undo, toggle bold, italic and underline and also option for changing font family and font size.

File Model contains functions such as saving, opening files.
File View Model contains ViewModel and RelayCommand witch simple implementation of ICommand interface.
To fully implement MVVM architecture document from RichTextBox in MainWindow.xmal needs to be binded to
ViewModel.cs.
