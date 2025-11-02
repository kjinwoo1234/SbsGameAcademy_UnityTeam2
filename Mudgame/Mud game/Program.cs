using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

public class Weapon // 무기 시스템 정의
{
    public string WeaponName { get; set; }
    public string WeaponDescription { get; set; }
    public string WeaponSeriesCha { get; set; }
    public int Attack { get; set; }
    public int WeaponPrice { get; set; }
    public string[] WeaponIcon { get; set; }

    public Weapon(string name, string desc, string cha, int atk, int price, string[] icon)
    {
        WeaponName = name;
        WeaponDescription = desc;
        WeaponSeriesCha = cha;
        Attack = atk;
        WeaponPrice = price;
        WeaponIcon = icon;
    }  
}

public class Armor // 방어구 시스템 정의
{
    public string ArmorName { get; set; }
    public string ArmorDescription { get; set; }

    public string ArmorSeriesCha { get; set; }
    public int Defend { get; set; }
    public int ArmorPrice { get; set; }
    public string[] ArmorIcon { get; set; }
    public Armor(string name, string desc, string cha, int def, int price, string[] icon)
    {
        ArmorName = name;
        ArmorDescription = desc;
        ArmorSeriesCha = cha;
        Defend = def;
        ArmorPrice = price;
        ArmorIcon = icon;
    }
}

public class Potion // 물약 시스템 정의
{
    public string PotionName { get; set; }
    public string PotionDescription { get; set; }
    public int HealAmount { get; set; }
    public int EnergyAmount { get; set; }
    public int PotionPrice { get; set; }
    public string[] PotionIcon { get; set; }

    public Potion(string name, string desc, int heal, int energy, int price, string[] icon)
    {
        PotionName = name;
        PotionDescription = desc;
        HealAmount = heal;
        EnergyAmount = energy;
        PotionPrice = price;
        PotionIcon = icon;

    }
}

public static class Shop
{
    public static List<Weapon> AvailableWeapons { get; set; } = new List<Weapon>();
    public static List<Armor> AvailableArmor { get; set; } = new List<Armor>();
    public static List<Potion> AvailablePotion { get; set; } = new List<Potion>();

    static Shop()
    {
        string[] swordShort = new string[]
        {
            "     ▲    ",
            "     ■    ",
            "     ■    ",
            "   □□□  ",
            "     □    ",
        };

        string[] twinSwordIron = new string[]
        {
            "     ▲    ",
            "     ■    ",
            "     ■    ",
            "     ■    ",
            "   □□□  ",
            "     ■    ",
            "     ■    ",
            "     ■    ",
            "     ▼    ",
        };

        string[] spearIron = new string[]
        {
            "     ▲    ",
            "     ■    ",
            "     ■    ",
            "     ■    ",
            "     ■    ",
            "     ■    ",
            "     ■    ",
            "     ■    ",
            "     ■    ",
            "     ■    ",
        };

        string[] fireCane = new string[]
        {
            "  ※ ●       ",
            "   ●♨● ※   ",
            "     ●        ",
            "     ●         ",
            " ※  ●    ※   ",
            "     ●         ",
            "     ●         ",
            "  ※ ●         ",
            "     ▼         ",
        };

        string[] windCane = new string[]
        {
            "  ~  ●         ",
            "   ●§● ~     ",
            "  ~  ●         ",
            "     ●         ",
            " ~   ●  ~  ~   ",
            "     ●         ",
            "     ●  ~      ",
            "     ●         ",
            "  ~  ◎         ",
        };

        string[] darkCane = new string[]
        {
            "     ★          ",
            "   ●▩●        ",
            "     ●          ",
            "     ●          ",
            "     ●          ",
            "     ●          ",
            "     ●          ",
            "     ●          ",
            "     ●          ",
        };

        string[] lightCane = new string[]
        {
            "  *  ○  *       ",
            "   ○☆○        ",
            "     ●     *    ",
            " *   ●          ",
            "     ●          ",
            "     ●     *    ",
            "     ●          ",
            "   * ●          ",
            "     ●          ",
        };

        string[] twoSwords = new string[]
        {
            "      ▲        ▲     ",
            "      ■        ■     ",
            "      ■        ■     ",
            "     □□      □□    ",
            "      □        □     ",
        };

        string[] middleSword = new string[]
        {
            "      ▲            ",
            "      ■            ",
            "      ■            ",
            "      ■            ",
            "      ■            ",
            "     ◇◇          ",
            "      ◇            ",
        };

        string[] shuriken = new string[]
        {
            "                    ",
            "     ◆             ",
            "   ◆◆◆    ◆     ",
            " ◆◆○◆◆◆  ◆   ",
            "   ◆◆◆    ◆     ",
            "     ◆             ",
            "                    ",
        };


        string[] flamingBow = new string[]
        {
            "            ▓〓〓   ",
            "         ▓▓〓   I    ",
            "        ▓〓〓☆ I    ",
            "       ▓〓〓  ★I    ",
            "   ☆ ▓▓〓〓☆  I    ",
            "  ←〓▓〓〓〓〓〓〓〓 ",
            "   ☆ ▓▓〓〓☆  I    ",
            "       ▓〓〓  ★I    ",
            "        ▓〓〓☆ I    ",
            "         ▓▓〓   I    ",
             "            ▓〓〓    ",
        };

        string[] flamingArrow = new string[]
        {
            "    ☆     △    ★   ",
            "           §         ",
            "           §         ",
            "           § ★      ",
            "       ☆  §         ",
            "           §         ",
            "           §         ",
            "           §      ☆ ",
            "        ★ §         ",
            "          ↗↖        ",
        };

        string[] frozenBow = new string[]
        {
            "            ▓〓〓    ",
            "         ▓▓〓   I    ",
            "        ▓〓〓※ I    ",
            "       ▓〓〓  ◎I    ",
            "   ※ ▓▓〓〓※  I    ",
            "  ←〓▓〓〓〓〓〓〓〓 ",
            "   ※ ▓▓〓〓※  I    ",
            "       ▓〓〓  ◎I    ",
            "        ▓〓〓※ I    ",
            "         ▓▓〓   I    ",
            "     ◎     ▓〓〓    ",

        };

        string[] frozenArrow = new string[]
        {
            "           △    ◎   ",
            "       ※  §         ",
            "           §         ",
            "           § ※      ",
            "           §         ",
            "       ※  §         ",
            "           §         ",
            "           §     ◎  ",
            "        ※ §         ",
            "     ◎   ↗↖        ",
        };

        string[] poisoningBow = new string[]
        {
            "            ▓〓〓    ",
            "         ▓▓〓 ◐I    ",
            "        ▓〓〓   I    ",
            "       ▓〓〓    I    ",
            "   ◐ ▓▓〓〓◑  I    ",
            "  ←〓▓〓〓〓〓〓〓〓 ",
            "      ▓▓〓〓    I    ",
            "       ▓〓〓    I    ",
            "        ▓〓〓 ◑I    ",
            "         ▓▓〓   I    ",
             "      ◑    ▓〓〓   ",
        };

        string[] poisoningArrow = new string[]
        {
            "           △   ◑    ",
            "       ◐  §         ",
            "        ◐ §         ",
            "           § ◐      ",
            "           §         ",
            "       ◑  §         ",
            "           §         ",
            "           § ◑      ",
            "        ◐ §         ",
            "     ◑   ↗↖        ",
        };

        string[] shieldWood = new string[]
        {
            "   ■ ■ ■ ■   ",
            "   ■ ===== ■   ",
            "   ■ ■ ■ ■   ",
            "   ■ ===== ■   ",
            "   ■ ■ ■ ■   ",
            "   ■ ===== ■   ",
            "   ■ ■ ■ ■   ",
        };

        string[] shieldIron = new string[]
        {
            "      ■ ■    ",
            "   ■ ===== ■   ",
            "  ■  ■ ■  ■   ",
            " ■ ========= ■   ",
            "  ■  ■ ■  ■   ",
            "   ■ ===== ■   ",
            "      ■ ■    ",
        };

        string[] leatherArmor = new string[]
        {
            "      ■ ■       ",
            "   ■       ■    ",
            "    ■     ■     ",
            "      ■ ■       ",
            "    ■     ■     ",
            "   ■ ===== ■   ",
            "   ■■   ■■    ",
        };

        string[] ironArmor = new string[]
        {
            "       ■ ■       ",
            "    ■      ■    ",
            "  ■  ■  ■  ■     ",
            "    ■■  ■■       ",
            "    ■      ■     ",
            "   ■  ■■  ■   ",
            "   ■■    ■■    ",
        };

        string[] bronzeArmor = new string[]
        {
            "      ■  ■       ",
            "   ■        ■    ",
            "  ■  ■  ■  ■     ",
            "      ■  ■       ",
            "    ■      ■     ",
            "   ■  ■■  ■   ",
            "  ■ ■    ■ ■    ",
        };

        string[] nikelArmor = new string[]
        {
            "      ■  ■       ",
            "   ■■    ■■    ",
            "  ■■■  ■■■     ",
            "    ■■  ■■       ",
            "    ■■  ■■     ",
            "   ■  ■■  ■   ",
            "  ■ ■    ■ ■    ",
        };

        string[] diamondArmor = new string[]
        {
            "    ■■    ■■       ",
            "   ■  ■  ■  ■      ",
            "   ■■■★■■■      ",
            " ■■■■  ■■■■      ",
            "   ■■■★■■■      ",
            "   ■  ■  ■  ■      ",
            "   ■ ■    ■ ■      ",
        };

        string[] endingArmor = new string[]
        {
            "     ☆      ☆     ",
            "   ■■■☆■■■      ",
            "   ■■■★■■■      ",
            " ■■■■☆■■■■      ",
            "   ■■■★■■■      ",
            "   ■  ■  ■  ■      ",
            "   ■■■  ■■■      ",
        };

        string[] hpPotion = new string[]
        {
            "        ■   + ",
            "   +   ■■    ",
            "      ■  ■   ",
            "   +  ■  ■  +",
            "      ■■■   ",
        };

        string[] energyPotion = new string[]
        {
            "        ■   ↑",
            "   ↑  ■■    ",
            "      ■  ■   ",
            "   ↑ ■  ■ ↑",
            "      ■■■   ",
        };


        AvailableWeapons.Add(new Weapon(
            "단검",
            "연습용으로 제작된 단검. 실전에서도 유용하다",
            "전사,암살자",
            2,
            25,
            swordShort
        ));

        AvailableWeapons.Add(new Weapon(
            "양날 검",
            "철을 제련하여 만든 양날의 검. 단검보다 파괴적이다.",
            "검사",
            2,
            60,
            twinSwordIron
        ));

        AvailableWeapons.Add(new Weapon(
            "창검",
            "철로 만든 날카롭고 긴 창검. 찌르는 무기답게 치명상을 줄 수 있다.",
            "검사",
            6,
            100,
            spearIron
        ));

        AvailableWeapons.Add(new Weapon(
            "이도류",
            "기습에 유용한 1쌍 단검. 공격속도가 월등하다",
            "암살자",
            2,
            70,
            twoSwords
        ));

        AvailableWeapons.Add(new Weapon(
            "은검",
            "단검보다 길고, 창보다 짧은 검. 암살자들의 주요 무기 중 하나.",
            "암살자",
            5,
            100,
            middleSword
        ));

        AvailableWeapons.Add(new Weapon(
            "수리검",
            "원거리형 투창식 검. 완벽한 암살자는 보이지 않는 곳에서도 임무를 완수한다.",
            "암살자",
            8,
            180,
            shuriken
        ));

        AvailableWeapons.Add(new Weapon(
            "화염 지팡이",
            "적을 공격시 불 데미지로 2턴동안 화염 데미지를 입힌다.",
            "마법사",
            2,
            22,
            fireCane
        ));

        AvailableWeapons.Add(new Weapon(
            "바람 지팡이",
            "바람으로 적을 공격하여 데미지가 낮다,",
            "마법사",
            1,
            30,
            windCane
        ));

        AvailableWeapons.Add(new Weapon(
            "어둠 지팡이",
            "어둠 지팡이로 적을 공격시 적을 1턴동안 실명으로 만들어 버린다.",
            "마법사",
            4,
            80,
            darkCane
        ));

        AvailableWeapons.Add(new Weapon(
            "빛 지팡이",
            "빛 지팡이로 적을 공격할시 적을 1턴동안 실명으로 만들어 버린다.",
            "마법사",
            4,
            80,
            lightCane
        ));

        AvailableWeapons.Add(new Weapon(
            "불붙은 활",
            "활대에 불꽃이 타오르는 강력한 활. 공격 시 추가 화염 피해를 입힌다.",
            "궁수",
            6,
            100,
            flamingBow
        ));

        AvailableWeapons.Add(new Weapon(
            "불꽃 화살",
            "불꽃이 타오르는 화살. 공격 시 추가 화염 피해를 입힌다.",
            "궁수",
            8,
            2,
            flamingArrow
        ));

        AvailableWeapons.Add(new Weapon(
            "얼어붙은 활",
            "주변에서도 한기가 느껴지는 얼어붙은 활. 공격 시 적이 일시적으로 느려진다.",
            "궁수",
            8,
            150,
            frozenBow
        ));

        AvailableWeapons.Add(new Weapon(
            "빙결 화살",
            "화살촉이 얼어붙은 화살. 공격 시 적이 일시적으로 느려진다.",
            "궁수",
            7,
            2,
            frozenArrow
        ));

        AvailableWeapons.Add(new Weapon(
            "독이 뭍은 활",
            "치명적인 독이 저장된 활. 공격 시 적이 중독상태에 빠진다.",
            "궁수",
            11,
            250,
            poisoningBow
        ));

        AvailableWeapons.Add(new Weapon(
            "중독 화살",
            "독이 응축된 화살촉의 화살. 공격 시 적이 중독상태에 빠진다.",
            "궁수",
            6,
            2,
            poisoningArrow
        ));

        AvailableArmor.Add(new Armor(
            "나무방패",
            "나무로 제작한 기본방패. 피해를 감경시킨다",
            "검사",
            3,
            40,
            shieldWood
        ));

        AvailableArmor.Add(new Armor(
            "철 방패",
            "철을 제련해 만든 방패. 나무보다 튼튼해보인다",
            "검사",
            5,
            100,
            shieldIron
        ));

        AvailableArmor.Add(new Armor(
            "가죽 갑옷",
            "두꺼운 가죽으로 만든 갑옷. 질겨서 잘찢기지 않는다",
            "공용",
            8,
            120,
            leatherArmor
        ));

        AvailableArmor.Add(new Armor(
            "철 갑옷",
            "단단한 철로 만든 갑옷. 내구성은 뛰어나나 열에 약하다",
            "공용",
            14,
            300,
            ironArmor
        ));

        AvailableArmor.Add(new Armor(
            "청동 갑옷",
            "청동을 제련해서 만든 갑옷. 철보다 단단하진 않지만 내구성이 좋다",
            "공용",
            12,
            240,
            bronzeArmor
        ));

        AvailableArmor.Add(new Armor(
            "니켈 갑옷",
            "니켈광물을 제련하여 만든갑옷. 내구성, 열에 모두 강하다",
            "공용",
            25,
            450,
            nikelArmor
        ));

        AvailableArmor.Add(new Armor(
            "다이아 갑옷",
            "다이아 광물을 제련하여 만든 갑옷. 내구성은 최강, 열에는 생각보다 취약",
            "공용",
            50,
            600,
            diamondArmor
        ));

        AvailableArmor.Add(new Armor(
            "최종 갑옷",
            "모든 능력을 갖춘 갑옷. 전장을 지배하는 자의 자격에 적합하다",
            "공용",
            300,
            1000000,
            endingArmor
        ));

        AvailablePotion.Add(new Potion(
            "체력 포션",
            "체력을 10만큼 회복시킨다",
            10,
            0,
            3,
            hpPotion
        ));

        AvailablePotion.Add(new Potion(
            "에너지 포션",
            "에너지를 15만큼 회복시킨다",
            0,
            15,
            5,
            energyPotion
        ));
    }
}

public static class ConsoleUI
{
    // 테두리 문자
    private const char Horizontal = '─';
    private const char Vertical = '│';
    private const char TopLeft = '┌';
    private const char TopRight = '┐';
    private const char BottomLeft = '└';
    private const char BottomRight = '┘';

    // 커서 위치를 안전하게 설정하는 함수
    public static void SafeSetCursorPosition(int x, int y)
    {
        int safeX = Math.Max(0, Math.Min(Console.WindowWidth - 1, x));
        int safeY = Math.Max(0, Math.Min(Console.WindowHeight - 1, y));

        try
        {
            Console.SetCursorPosition(safeX, safeY);
        }
        catch
        {
            // 콘솔 리사이즈 중 오류 방지
        }
    }

    // 박스 그리기
    public static void DrawBox(out int width, out int height)
    {
        width = Console.WindowWidth;
        height = Console.WindowHeight;

        Console.CursorVisible = false;

        // 위쪽
        SafeSetCursorPosition(0, 0);
        Console.Write(TopLeft + new string(Horizontal, width - 2) + TopRight);

        // 가운데
        for (int i = 1; i < height - 1; i++)
        {
            SafeSetCursorPosition(0, i);
            Console.Write(Vertical);
            SafeSetCursorPosition(width - 1, i);
            Console.Write(Vertical);
        }

        // 아래쪽
        SafeSetCursorPosition(0, height - 1);
        Console.Write(BottomLeft + new string(Horizontal, width - 2) + BottomRight);
    }

    public static void DisplayWeaponDetails(Weapon weapon, int boxWidth, int boxHeight)
    {
        int startX = 2;
        int startY = 2;
        int splitX = boxWidth / 3;

        // --- 아이콘 ---
        int iconX = startX + (splitX / 2) - (weapon.WeaponIcon[0].Length / 2);

        for (int i = 0; i < weapon.WeaponIcon.Length; i++)
        {
            if (startY + i < boxHeight - 2)
            {
                SafeSetCursorPosition(iconX, startY + i);

                foreach (char c in weapon.WeaponIcon[i])
                {
                    if (weapon.WeaponName == "불붙은 활" || weapon.WeaponName == "불꽃 화살")
                    {
                        if (c == '★' || c == '☆' || c == '←' || c == '△')
                            Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.Yellow : ConsoleColor.Red; // 깜빡이는 불빛
                        else if (c == '〓')
                            Console.ForegroundColor = ConsoleColor.DarkGray; // 화살대
                        else if (c == '▓')
                            Console.ForegroundColor = ConsoleColor.DarkYellow; // 활대
                        else
                            Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if(weapon.WeaponName == "얼어붙은 활" || weapon.WeaponName == "빙결 화살")
                    {
                        if (c == '◎' || c == '※' || c == '←' || c == '△')
                            Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.Cyan : ConsoleColor.Blue; // 깜빡이는 불빛
                        else if (c == '〓')
                            Console.ForegroundColor = ConsoleColor.DarkGray; // 화살대
                        else if (c == '▓')
                            Console.ForegroundColor = ConsoleColor.DarkYellow; // 활대
                        else
                            Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (weapon.WeaponName == "독이 뭍은 활" || weapon.WeaponName == "중독 화살")
                    {
                        if (c == '◐' || c == '◑' || c == '←' || c == '△')
                            Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.DarkGreen : ConsoleColor.Green; // 깜빡이는 불빛
                        else if (c == '〓')
                            Console.ForegroundColor = ConsoleColor.DarkGray; // 화살대
                        else if (c == '▓')
                            Console.ForegroundColor = ConsoleColor.DarkYellow; // 활대
                        else
                            Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (weapon.WeaponName == "수리검")
                    {
                        if (c == '◆')
                            Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.DarkGray : ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(c);
                }
            }
        }

        // --- 오른쪽 설명 ---
        int textX = splitX + 5;
        int textY = startY;

        SafeSetCursorPosition(textX, textY++);
        Console.Write($"이름: {weapon.WeaponName}");

        SafeSetCursorPosition(textX, textY++);
        Console.Write($"직업군: {weapon.WeaponSeriesCha}");

        SafeSetCursorPosition(textX, textY++);
        Console.Write($"공격력: {weapon.Attack}");

        SafeSetCursorPosition(textX, textY++);
        Console.Write($"가격: {weapon.WeaponPrice} 골드");
        textY += 2;

        SafeSetCursorPosition(textX, textY++);
        Console.Write("설명:");

        string description = weapon.WeaponDescription;
        int maxTextWidth = boxWidth - textX - 3;

        for (int i = 0; i < description.Length; i += maxTextWidth)
        {
            if (textY < boxHeight - 3)
            {
                string line = description.Substring(i, Math.Min(maxTextWidth, description.Length - i));
                SafeSetCursorPosition(textX, textY++);
                Console.Write(line);
            }
        }
    }

    public static void DisplayArmorDetails(Armor armor, int boxWidth, int boxHeight)
    {
        int startX = 2;
        int startY = 2;
        int splitX = boxWidth / 3;

        int iconX = startX + (splitX / 2) - (armor.ArmorIcon[0].Length / 2);

        for(int i = 0; i < armor.ArmorIcon.Length; i++)
        {
            if (startY + i < boxHeight - 2)
            {
                SafeSetCursorPosition(iconX, startY + i);
                Console.Write(armor.ArmorIcon[i]);
            }
        }

        int textX = splitX + 5;
        int textY = startY;

        SafeSetCursorPosition(textX, textY++);
        Console.Write($"이름: {armor.ArmorName}");

        SafeSetCursorPosition(textX, textY++);
        Console.Write($"직업군: {armor.ArmorSeriesCha}");

        SafeSetCursorPosition(textX, textY++);
        Console.Write($"방어력: {armor.Defend}");

        SafeSetCursorPosition(textX, textY++);
        Console.Write($"가격: {armor.ArmorPrice} 골드");
        textY += 2;

        SafeSetCursorPosition(textX, textY++);
        Console.Write("설명:");

        string desc = armor.ArmorDescription;
        int maxWidth = boxWidth - textX - 3;
        for (int i = 0; i < desc.Length; i += maxWidth)
        {
            if (textY < boxHeight - 3)
            {
                string line = desc.Substring(i, Math.Min(maxWidth, desc.Length - i));
                SafeSetCursorPosition(textX, textY++);
                Console.Write(line);
            }
        }
    }

    public static void DisplayPotionDetails(Potion potion, int boxWidth, int boxHeight)
    {
        int startX = 2;
        int startY = 2;
        int splitX = boxWidth / 3;

        int iconX = startX + (splitX / 2) - (potion.PotionIcon[0].Length / 2);

        for (int i = 0; i < potion.PotionIcon.Length; i++)
        {
            if (startY + i < boxHeight - 2)
            {
                SafeSetCursorPosition(iconX, startY + i);
                Console.Write(potion.PotionIcon[i]);
            }
        }

        int textX = splitX + 5;
        int textY = startY;

        SafeSetCursorPosition(textX, textY++);
        Console.Write($"이름: {potion.PotionName}");

        SafeSetCursorPosition(textX, textY++);
        Console.Write($"hp회복량: {potion.HealAmount}");

        SafeSetCursorPosition(textX, textY++);
        Console.Write($"에너지회복량: {potion.EnergyAmount}");

        SafeSetCursorPosition(textX, textY++);
        Console.Write($"가격: {potion.PotionPrice} 골드");
        textY += 2;

        SafeSetCursorPosition(textX, textY++);
        Console.Write("설명:");

        string desc = potion.PotionDescription;
        int maxWidth = boxWidth - textX - 3;
        for (int i = 0; i < desc.Length; i += maxWidth)
        {
            if (textY < boxHeight - 3)
            {
                string line = desc.Substring(i, Math.Min(maxWidth, desc.Length - i));
                SafeSetCursorPosition(textX, textY++);
                Console.Write(line);
            }
        }
    }
}

enum ShopMode
{
    Weapon,
    Armor,
    Potion
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (Console.WindowWidth < 80) Console.WindowWidth = 80;
            if (Console.WindowHeight < 25) Console.WindowHeight = 25;
        }
        catch { }

        int gold = 100; // 플레이어 시작 골드
        int selectedIndex = 0;
        ShopMode currentMode = ShopMode.Weapon;

        Console.CursorVisible = false;
        Console.Clear();
        ConsoleUI.DrawBox(out int width, out int height);
        int prevWidth = width, prevHeight = height;

        while (true)
        {
            width = Console.WindowWidth;
            height = Console.WindowHeight;

            if (width < 40 || height < 15)
            {
                Console.Clear();
                Console.WriteLine("콘솔 창 크기가 너무 작습니다. (40x15 이상 추천)");
                System.Threading.Thread.Sleep(200);
                continue;
            }

            if (width != prevWidth || height != prevHeight)
            {
                Console.Clear();
                ConsoleUI.DrawBox(out width, out height);
                prevWidth = width;
                prevHeight = height;
            }

            string titleText;

            if (currentMode == ShopMode.Weapon)
                titleText = "[무기 상점]";
            else if (currentMode == ShopMode.Armor)
                titleText = "[방어구 상점]";
            else 
                titleText = "[포션 상점]";
            string sizeInfo = $"{width} x {height}";

            ConsoleUI.SafeSetCursorPosition(2, 1);
            Console.Write(new string(' ', width - 4));

            ConsoleUI.SafeSetCursorPosition(2, 1);
            Console.Write(titleText);

            ClearContentArea(width, height);

            if (currentMode == ShopMode.Weapon)
                ConsoleUI.DisplayWeaponDetails(Shop.AvailableWeapons[selectedIndex], width, height);
            else if (currentMode == ShopMode.Armor)
                ConsoleUI.DisplayArmorDetails(Shop.AvailableArmor[selectedIndex], width, height);
            else
                ConsoleUI.DisplayPotionDetails(Shop.AvailablePotion[selectedIndex], width, height);

            string info = $"← → : 항목 이동 | Enter : 구매 | Tab : 상점 전환 | Gold : {gold} | ESC : 종료";
            ConsoleUI.SafeSetCursorPosition(2, height - 2);
            Console.Write(new string(' ', width - 4));
            ConsoleUI.SafeSetCursorPosition(2, height - 2);
            Console.Write(info);

            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.LeftArrow)
                    selectedIndex--;
                else if (key == ConsoleKey.RightArrow)
                    selectedIndex++;
                else if (key == ConsoleKey.Tab)
                {
                    switch (currentMode)
                    {
                        case ShopMode.Weapon:
                            currentMode = ShopMode.Armor;
                            break;
                        case ShopMode.Armor:
                            currentMode = ShopMode.Potion;
                            break;
                        case ShopMode.Potion:
                            currentMode = ShopMode.Weapon;
                            break;
                    }
                    selectedIndex = 0;
                    Console.Clear();
                    ConsoleUI.DrawBox(out width, out height);
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (currentMode == ShopMode.Weapon)
                    {
                        var item = Shop.AvailableWeapons[selectedIndex];
                        if (gold >= item.WeaponPrice)
                        {
                            gold -= item.WeaponPrice;
                            ShowMessage($"'{item.WeaponName}' 구매 완료! (-{item.WeaponPrice} 골드)", width, height);
                        }
                        else ShowMessage("골드가 부족합니다!", width, height);
                    }
                    else if (currentMode == ShopMode.Armor)
                    {
                        var item = Shop.AvailableArmor[selectedIndex];
                        if (gold >= item.ArmorPrice)
                        {
                            gold -= item.ArmorPrice;
                            ShowMessage($"'{item.ArmorName}' 구매 완료! (-{item.ArmorPrice} 골드)", width, height);
                        }
                        else ShowMessage("골드가 부족합니다!", width, height);
                    }
                    else
                    {
                        var item = Shop.AvailablePotion[selectedIndex];
                        if (gold >= item.PotionPrice)
                        {
                            gold -= item.PotionPrice;
                            ShowMessage($"'{item.PotionName}' 구매 완료! (-{item.PotionPrice} 골드)", width, height);
                        }
                        else ShowMessage("골드가 부족합니다!", width, height);
                    }
                }
                else if (key == ConsoleKey.Escape)
                    break;

                int count = 0;

                switch (currentMode)
                {
                    case ShopMode.Weapon:
                        count = Shop.AvailableWeapons.Count;
                        break;
                    case ShopMode.Armor:
                        count = Shop.AvailableArmor.Count;
                        break;
                    case ShopMode.Potion:
                        count = Shop.AvailablePotion.Count;
                        break;
                }
                selectedIndex = (selectedIndex + count) % count;
            }

            System.Threading.Thread.Sleep(50);
        }

        Console.Clear();
        Console.CursorVisible = true;
    }

    static void ClearContentArea(int width, int height)
    {
        string clearLine = new string(' ', width - 2);
        for (int y = 2; y < height - 2; y++)
        {
            ConsoleUI.SafeSetCursorPosition(1, y);
            Console.Write(clearLine);
        }
    }

    static void ShowMessage(string message, int width, int height)
    {
        ConsoleUI.SafeSetCursorPosition(2, height - 3);
        Console.Write(new string(' ', width - 4));
        ConsoleUI.SafeSetCursorPosition(2, height - 3);
        Console.Write(message);
        System.Threading.Thread.Sleep(1000);
    }
}
