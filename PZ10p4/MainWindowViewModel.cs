using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace PZ10p4;

public class MainWindowViewModel : ObservableObject {
    private ObservableCollection<Note> _notes = new ObservableCollection<Note>();

    public ObservableCollection<Note> Notes {
        get => _notes;
        set => SetProperty(ref _notes, value);
    }

    public ObservableCollection<Note> CompletedNotes { get; set; } = new();

    public Note SelectedNote { get; set; }

    public Note SelectedCompletedNote { get; set; }
    public ICommand DeleteCommand { get; }

    public MainWindowViewModel() {
        DeleteCommand = new Command(RemoveSelectedNote);
        Notes.CollectionChanged += NotesOnCollectionChanged;
        Notes.Add(new Note($"Заметка 1"));
        CompletedNotes.Add(new Note("Выполненная заметка 1") {IsCompleted = true});
    }

    private void NotesOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) {
        var newItems = e.NewItems as List<Note>;
        if (newItems is null) return;
        for (int i = 0; i < newItems.Count; i++) {
            if (newItems[i].IsCompleted) {
                Notes.Remove(newItems[i]);
                CompletedNotes.Add(newItems[i]);
            }
        }
    }

    public void RemoveSelectedNote() {
        if (SelectedCompletedNote is null) return;
        CompletedNotes.Remove(SelectedCompletedNote);
    }

    public void AddNote() {
        Notes.Add(new Note());
    }
}