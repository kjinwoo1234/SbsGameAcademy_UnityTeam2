using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace MUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // 메인 메뉴 실행
                string[] items = { "종료", "검      - 대마시아!", "지팡이  - 마법딜도 좋지만 물리딜도 좋다.", "활      - 리그 오브 레전드에 애쉬가 쓰던 활 이라는 전설이 있다.", "화살    - 그냥 화살이다.(뭘 바라는거지...?)", "방어구  - 아픈건 싫어서 방어구에 몰빵했습니다.", "물약    - 딸기향과 소다 향이 나는 물약이다" };
                int selectIndex = ExecuteMenu("인벤토리", items);
                // 서브 메뉴 실행
                switch (selectIndex)
                {
                    case 0: // 종료
                        return;
                    case 1: // 검
                        string[] listSword = { "뒤로", "단검", "장검", "양날검", "검과 방패" };
                        selectIndex = ExecuteMenu("인벤토리>검", listSword);
                        break;
                    case 2: // 지팡이
                        string[] listStaff = { "뒤로", "땅 지팡이", "화염 지팡이", "바람 지팡이", "어둠 지팡이", "빛 지팡이" };
                        selectIndex = ExecuteMenu("인벤토리>지팡이", listStaff);
                        break;
                    case 3: // 활
                        string[] listBow = { "뒤로", "기본 활", "다중발사 활", "빠른활", "데미지활" };
                        selectIndex = ExecuteMenu("인벤토리>활", listBow);
                        break;
                    case 4: // 화살
                        string[] listArrow = { "뒤로", "기본 화살", "화염 화살", "얼음 화살", "독 화살", "다크 화살" };
                        selectIndex = ExecuteMenu("인벤토리>화살", listArrow);
                        break;
                    case 5: //방어구
                        string[] listarmor = { "뒤로", "가죽 갑옷", "구리 갑옷", "철 갑옷", "?@#$% 갑옷" };
                        selectIndex = ExecuteMenu("인벤토리>방어구", listarmor);
                        break;
                    case 6: //물약
                        string[] listpotion = { "뒤로", "소형 체력 회복 포션", "중형 체력 회복 포션", "대형 체력 회복 포션", "", "소형 마나 회복 포션", "중형 마나 회복 포션", "대형 마나 회복 포션" };
                        selectIndex = ExecuteMenu("인벤토리>물약", listpotion);
                        break;
                }
            }
        }

        // 메뉴 실행
        static int ExecuteMenu(string title, string[] items)
        {
            // 커서 숨기기
            Console.CursorVisible = false;

            // 아이템 선택 번호
            int selectIndex = 0;

            while (true)
            {
                // 콘솔창 초기화
                Console.Clear();

                // 상단 제목 출력
                Console.WriteLine("[" + title + "]");

                // 메뉴 출력
                for (int i = 0; i < items.Length; i++)
                {
                    if (i == selectIndex)
                        Console.WriteLine("->" + items[i]); // 선택된 메뉴 앞에는 화살표 추가하여 출력
                    else
                        Console.WriteLine("  " + items[i]); // 선택안된 메뉴는 그냥 그대로 출력
                }

                // 키보드 입력
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow)
                {
                    // 위 입력시 선택번호 감소, 번호가 처음보다 작아지면 마지막으로
                    selectIndex--;
                    if (selectIndex < 0)
                        selectIndex = items.Length - 1;
                }

                else if (key.Key == ConsoleKey.DownArrow)
                {
                    // 아래 입력시 선택번호 증가, 번호가 마지막을 넘으면 처음으로
                    selectIndex++;
                    if (selectIndex >= items.Length)
                        selectIndex = 0;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    // 엔터 입력시 무한반복 탈출 및 선택번호 반환
                    return selectIndex;
                }
            }
        }

    }
}