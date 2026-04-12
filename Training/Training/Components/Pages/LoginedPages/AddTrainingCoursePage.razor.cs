using DocumentsLibrary;
using Microsoft.JSInterop;
using Radzen;
using Training.Components.Pages.Base;
namespace Training.Components.Pages.LoginedPages;

public class AddTrainingCoursePageModel: BaseAddModel<TrainingCourse>
{
    [Inject] IJSRuntime JS { get; set; } = default!;

    protected OperationResponce<string?>? SaveExcelOperationResponce { get; set; }
    protected OperationResponce<bool?>? JSTransferExcelOperationResponce { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (EditedEntityId > 0)
        {
            LoadEntityOperationResponce = await DbRepository.GetCourse(EditedEntityId);
            MainEntity = LoadEntityOperationResponce.Data;
        }
        else
        {
            MainEntity = new(MyUser);
        }
        await base.OnParametersSetAsync();
    }

    /// <summary>
    /// Добавляемая карточка
    /// </summary>
    protected CourseQestion? AddedCourseQestion { get; set; }
    private CourseQestion? SelectedForEditCourseQestion { get; set; }

    /// <summary>
    /// Добавляемое ошибочное слово
    /// </summary>
    protected WrongRussianWordAnswer? AddingWrongWord { get; set; }

    /// <summary>
    /// Показывать поля карточки
    /// </summary>
    protected bool IsShowAddingCard { get; set; } = false;
    
    /// <summary>
    /// Сейчас редактирование
    /// </summary>
    protected bool IsEditingCard { get; set; } = false;

    protected bool IsAddWrongWord { get; set; } = false;

    /// <summary>
    /// Сохранить карточку
    /// </summary>
    protected void OnAddCardClick()
    {
        if (IsEditingCard)
        {
            AddedCourseQestion!.CopyTo(SelectedForEditCourseQestion!);
        }
        else
        {

            if (MainEntity!.CourseQestions == null)
                MainEntity.CourseQestions = new List<CourseQestion>();
            MainEntity.CourseQestions.Add(AddedCourseQestion!);
        }

        IsShowAddingCard = false;
        IsEditingCard = false;
    }

    /// <summary>
    /// Создать новую карточку
    /// </summary>
    protected void OnCreateNewCardClick()
    {
        IsShowAddingCard = true;
        IsEditingCard = false;
        AddedCourseQestion = new() { TrainingCourse = MainEntity };
    }

    /// <summary>
    /// Редактировать карточку
    /// </summary>
    /// <param name="entity">Редактируемая карточка</param>
    public async Task OnQestionEditClick(CourseQestion entity)
    {
        SelectedForEditCourseQestion = entity;
        AddedCourseQestion = new();
        entity.CopyTo(AddedCourseQestion);
        IsShowAddingCard = true;
        IsEditingCard = true;
    }

    

    public async Task OnDeleteWrongWordClick(CourseQestion entity, WrongRussianWordAnswer wordAnswer)
    {
        var forDel= entity.WrongRussianWordAnswers?.FirstOrDefault(wordAnswer);
        if (forDel != null)
            entity.WrongRussianWordAnswers?.Remove(forDel);
    }

    public async Task OnAddWrongWordClick(CourseQestion entity)
    {
        IsAddWrongWord = true;
        AddingWrongWord = new() { CourseQestion = entity };
    }

    public async Task OnCancelAddWrongWordClick(CourseQestion entity)
    {
        IsAddWrongWord = false;
        AddingWrongWord = null;
    }

    public async Task OnSaveWrongWordClick(CourseQestion entity)
    {
        if (AddingWrongWord == null)
            return;

        if (entity.WrongRussianWordAnswers == null)
            entity.WrongRussianWordAnswers = new List<WrongRussianWordAnswer>();
        entity.WrongRussianWordAnswers.Add(AddingWrongWord);
        IsAddWrongWord = false;
        
    }

    /// <summary>
    /// Отмена добавления/редактирования карточки
    /// </summary>
    public void OnCancelAddQestionClick()
    {
        IsShowAddingCard = false;
        IsEditingCard = false;
        AddedCourseQestion = null;
    }

    /// <summary>
    /// Удалить карточку из курса
    /// </summary>
    /// <param name="entity">Удаляемая карточка</param>
    public async Task OnQestionDeleteClick(CourseQestion entity)
    {
        var deletd= MainEntity!.CourseQestions?.FirstOrDefault(x=> x.Id == entity.Id
            && x.RussianWord==entity.RussianWord
            && x.KanjiWord== entity.KanjiWord
            && x.KatakanaWord == entity.KatakanaWord
            && x.HiraganaWord == entity.HiraganaWord);

        if (deletd != null)
            MainEntity.CourseQestions?.Remove(deletd);
    }

    protected override void GoAfterSave()
    {
        NavigationManager.NavigateTo(ProjectRouters.allTrainingCoursesPageHref);
    }

    protected async Task LoadExcel()
    { 
    
    }

    protected async Task SaveExcel()
    {
        JSTransferExcelOperationResponce = null;
        SaveExcelOperationResponce = null;

        var excel = new TrainingCourseExcelExporter();
        SaveExcelOperationResponce = await excel.ExportCourseToExcelAsync(MainEntity);
        if(!SaveExcelOperationResponce.IsSuccessfullOperation)
        {
            NotifyUser("Ошибка при создании excel-файла", "Ошибка", NotificationSeverity.Warning);
            return;
        }

        try
        {
            var fileName = SaveExcelOperationResponce.Data;
            var fileStream = File.OpenRead(fileName);
            using var streamRef = new DotNetStreamReference(stream: fileStream);
            await JS.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);

            JSTransferExcelOperationResponce = OperationResponce<bool?>.SetSuccessfullOperation(true, "excel-файл успешно передан");
        }
        catch (Exception ex)
        {
            JSTransferExcelOperationResponce = OperationResponce<bool?>.SetExceptionOperation("Ошибка при передаче excel-файла", ex);
        }

    }
}
