using System;

namespace PZ10p4;

public class Note : ObservableObject {
    private string _text;
    private bool _isCompleted;

    /// <summary>
    /// Всегда уникальный идектификатор заметки
    /// </summary>
    public Guid Id { get; } = Guid.NewGuid();

    public string Text {
        get => _text;
        set => SetPropertyIfChanged(ref _text, value);
    }

    public bool IsCompleted {
        get => _isCompleted;
        set => SetProperty(ref _isCompleted, value);
    }

    public Note(string text) {
        _text = text;
    }

    public Note() : this("") {
    }
}