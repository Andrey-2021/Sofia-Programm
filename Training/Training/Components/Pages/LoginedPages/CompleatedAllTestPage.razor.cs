using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Training.Components.Pages.LoginedPages;

public class CompleatedAllTestPageModel : BaseShowAllDataModel<CompletedTest>
{
    /// <summary>
    /// Средний результат
    /// </summary>
    protected string? AverageResult => string.Format("{0:f2}",(Entities?.Sum(x => x.PercentageResult) / (Entities?.Count() ?? 1)));
    //protected decimal? AverageResult => Entities?.Sum(x => x.PercentageResult)/(Entities?.Count()??1);

    /// <summary>
    /// Общее количество вопросов
    /// </summary>
    protected decimal? TotalQuestionsNumber => Entities?.Sum(x => x.QestionNumber);

    /// <summary>
    /// Всего правильных ответов
    /// </summary>
    protected decimal? TotalCorrectAnswers => Entities?.Sum(x => x.CountCorrectAnswers);

    protected int Index { get; set; }

    protected override async Task LoadEntetiesAsync()
    {
        Index = 0;
        IsBusy = true;
        LoadEntitiesOperationResponce = await DbRepository.GetAllMyCompletedTest(MyUser);  //await DbRepository.GetEntitiesAsync<CompletedTest>(include: x=>x.Include(tc=>tc.TrainingCourse));
        Entities = LoadEntitiesOperationResponce.Data;
        IsBusy = false;
        if (LoadEntitiesOperationResponce.IsSuccessfullOperation)
            NotifyUser("Данные прочитаны");
    }
}

