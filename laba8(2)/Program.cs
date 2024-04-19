Console.WriteLine("Введите данные сотрудника:");

Console.Write("Фамилия Имя Отчество: ");
string fullName = Console.ReadLine();

Console.Write("Оклад: ");
double salary;
while (!double.TryParse(Console.ReadLine(), out salary))
{
    Console.WriteLine("Некорректный ввод. Пожалуйста, введите число для оклада.");
    Console.Write("Оклад: ");
}

Console.Write("Год поступления на работу: ");
int startYear;
while (!int.TryParse(Console.ReadLine(), out startYear))
{
    Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число для года поступления на работу.");
    Console.Write("Год поступления на работу: ");
}

Console.Write("Процент надбавки: ");
double bonusPercentage;
while (!double.TryParse(Console.ReadLine(), out bonusPercentage))
{
    Console.WriteLine("Некорректный ввод. Пожалуйста, введите число для процента надбавки.");
    Console.Write("Процент надбавки: ");
}

Console.Write("Подоходный налог (%): ");
double incomeTax;
while (!double.TryParse(Console.ReadLine(), out incomeTax))
{
    Console.WriteLine("Некорректный ввод. Пожалуйста, введите число для подоходного налога.");
    Console.Write("Подоходный налог (%): ");
}

Console.Write("Количество отработанных дней в месяце: ");
int workedDays;
while (!int.TryParse(Console.ReadLine(), out workedDays))
{
    Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число для количества отработанных дней в месяце.");
    Console.Write("Количество отработанных дней в месяце: ");
}

Console.Write("Количество рабочих дней в месяце: ");
int workingDaysPerMonth;
while (!int.TryParse(Console.ReadLine(), out workingDaysPerMonth))
{
    Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число для количества рабочих дней в месяце.");
    Console.Write("Количество рабочих дней в месяце: ");
}

SalaryEmployee employee = new SalaryEmployee(fullName, salary, startYear, bonusPercentage, incomeTax, workedDays, workingDaysPerMonth);

double accruedAmount = employee.CalculateAccruedAmount();
double withheldAmount = employee.CalculateWithheldAmount();
double netSalary = employee.CalculateNetSalary();
int yearsOfWork = employee.CalculateYearsOfWork();

Console.WriteLine("\nРасчеты для сотрудника:");
Console.WriteLine("ФИО: " + fullName);
Console.WriteLine("Начисленная сумма: " + accruedAmount);
Console.WriteLine("Удержанная сумма: " + withheldAmount);
Console.WriteLine("Зарплата на руки: " + netSalary);
Console.WriteLine("Стаж работы: " + yearsOfWork + " лет");

Console.ReadLine();


// Интерфейс для оплаты
public interface IPayment
{
    double CalculateAccruedAmount();
    double CalculateWithheldAmount();
    double CalculateNetSalary();
}

// Абстрактный класс для работника
public abstract class Employee : IPayment
{
    protected string fullName;
    protected double salary;
    protected int startYear;
    protected double bonusPercentage;
    protected double incomeTax;
    protected int workedDays;
    protected int workingDaysPerMonth;
    protected double accruedAmount;
    protected double withheldAmount;

    public Employee(string fullName, double salary, int startYear, double bonusPercentage, double incomeTax, int workedDays, int workingDaysPerMonth)
    {
        this.fullName = fullName;
        this.salary = salary;
        this.startYear = startYear;
        this.bonusPercentage = bonusPercentage;
        this.incomeTax = incomeTax;
        this.workedDays = workedDays;
        this.workingDaysPerMonth = workingDaysPerMonth;
    }

    public abstract double CalculateAccruedAmount();

    public abstract double CalculateWithheldAmount();

    public double CalculateNetSalary()
    {
        return accruedAmount - withheldAmount;
    }

    public int CalculateYearsOfWork()
    {
        int currentYear = DateTime.Now.Year;
        return currentYear - startYear;
    }
}

// Конкретный класс для работника с фиксированным окладом
public class SalaryEmployee : Employee
{
    public SalaryEmployee(string fullName, double salary, int startYear, double bonusPercentage, double incomeTax, int workedDays, int workingDaysPerMonth)
        : base(fullName, salary, startYear, bonusPercentage, incomeTax, workedDays, workingDaysPerMonth)
    {
    }

    public override double CalculateAccruedAmount()
    {
        double baseSalary = (salary / workingDaysPerMonth) * workedDays;
        double bonusAmount = baseSalary * (bonusPercentage / 100);
        accruedAmount = baseSalary + bonusAmount;
        return accruedAmount;
    }

    public override double CalculateWithheldAmount()
    {
        double pensionContribution = accruedAmount * 0.01; // 1% to pension fund
        double taxAmount = accruedAmount * (incomeTax / 100);
        withheldAmount = pensionContribution + taxAmount;
        return withheldAmount;
    }
}

