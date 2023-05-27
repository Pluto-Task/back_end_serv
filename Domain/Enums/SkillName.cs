using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum SkillName
{
    [Display(Name = "Психологічна допомога")]
    PsychologicalAssistance = 1,

    [Display(Name = "Медична допомога")]
    MedicalCare,

    [Display(Name = "Догляд за хворими")]
    NursingCare,

    [Display(Name = "Догляд за дітьми")]
    ChildCare,

    [Display(Name = "Медичні тренінги")]
    MedicalTraining,

    [Display(Name = "Військові тренінги")]
    MilitaryTraining,

    [Display(Name = "Перевезення вантажів")]
    TransportGoods,

    [Display(Name = "Перевезення людей")]
    TransportPeople,

    [Display(Name = "Ремонт техніки")]
    RepairEquipment,

    [Display(Name = "Приготування їжі")]
    FoodPreparation,

    [Display(Name = "Переклади")]
    Translation,

    [Display(Name = "Пошиття одягу")]
    SewingClothes,

    [Display(Name = "Плетіння сіток")]
    WeavingNets,

    [Display(Name = "Допомога на складі")]
    HelpWarehouse,

    [Display(Name = "Розбір завалів")]
    DebrisRemoval
}