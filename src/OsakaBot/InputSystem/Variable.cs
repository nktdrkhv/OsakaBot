using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Osaka.Bot.InputSystem;

[Table("Variable")]
public class Variable
{
    [Key] public string Name { get; set; } = null!;
    public string ShowedName { get; set; } = null!;
    public VariableType Type { get; set; } = VariableType.Standart;
}