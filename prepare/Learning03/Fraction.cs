using System;
class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int numerator)
    {
        _top = numerator;
        _bottom = 1;
    }
    public Fraction(int numerator, int denominator)
    {
        _top = numerator;
        if (denominator != 0)
        {
            SetBottom(denominator);
        }
        else _bottom = 1;
    }
    public int GetTop()
    {
        return _top;
    }
    public void SetTop(int numerator)
    {
        _top =  numerator;
    }
    public int GetBottom()
    {
        return _bottom;
    }
    public void SetBottom(int denominator)
    {
        _bottom = denominator;
    }
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}