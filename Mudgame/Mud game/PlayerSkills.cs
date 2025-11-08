using System;
using System.Collections.Generic;
using System.Linq;

namespace Mud_game
{
    public enum SkillType
    {
        Combat,  // 전투 스킬
        Special  // 필드 스킬
    }

    public class Skill
    {
        public string SkillName { get; set; }
        public SkillType Type { get; set; }
        public string Description { get; set; }
        public int MpCost { get; set; }
    }

    public static class PlayerSkills
    {
        // 스킬 데이터베이스
        private static Dictionary<string, Skill> _skillDatabase = new Dictionary<string, Skill>();

        // 플레이어 소유 스킬
        public static List<Skill> LearnedSkills { get; private set; } = new List<Skill>();

        static PlayerSkills()
        {
            InitializeSkills();
        }

        // 스킬 데이터베이스 초기화 메서드
        private static void InitializeSkills()
        {
            skillDatabase.Add("inCombatHide", new Skill
            {
                SkillName = "은신",
                Type = SkillType.Combat,
                Description = "전투 중에 적의 시야에서 사라집니다.",
                MpCost = 12
            });

            skillDatabase.Add("inFieldHide", new Skill
            {
                SkillName = "은신",
                Type = SkillType.Special,
                Description = "주변 환경에 몸을 숨깁니다.",
                MpCost = 8
            });

            skillDatabase.Add("doubleJump", new Skill
            {
                SkillName = "이단 점프",
                Type = SkillType.Special,
                Description = "한 번 더 점프할 수 있습니다.",
                MpCost = 8
            });

            skillDatabase.Add("ladderInstall", new Skill
            {
                SkillName = "사다리 설치",
                Type = SkillType.Special,
                Description = "사다리를 설치하여 높은 곳에 오를 수 있습니다.",
                MpCost = 0
            });

            skillDatabase.Add("Detect Trap", new Skill
            {
                SkillName = "함정 탐지", 
                Type = SkillType.Special,
                Description = "주변의 함정을 감지합니다.",
                MpCost = 5
            });

            skillDatabase.Add("Thrust", new Skill
            {
                SkillName = "찌르기", 
                Type = SkillType.Combat,
                Description = "적 하나를 강하게 찌릅니다.",
                MpCost = 5
            });

            skillDatabase.Add("Smite", new Skill
            {
                SkillName = "강타", 
                Type = SkillType.Combat,
                Description = "적 하나를 강하게 내려칩니다.",
                MpCost = 10
            });

            skillDatabase.Add("shiledBash", new Skill
            {
                SkillName = "방패 밀치기", 
                Type = SkillType.Combat,
                Description = "방패로 적을 밀쳐냅니다.",
                MpCost = 7
            });

            skillDatabase.Add("Fireball", new Skill
            {
                SkillName = "파이어볼", 
                Type = SkillType.Combat,
                Description = "불덩어리를 던져 적에게 화염 피해를 입힙니다.",
                MpCost = 15
            });

            skillDatabase.Add("inFieldHeal", new Skill
            {
                SkillName = "힐", 
                Type = SkillType.Special,
                Description = "자신이나 아군의 체력을 회복합니다.",
                MpCost = 18
            });

            skillDatabase.Add("inCombatHeal", new Skill
            {
                SkillName = "힐", 
                Type = SkillType.Combat,
                Description = "자신이나 아군의 체력을 회복합니다.",
                MpCost = 18
            });

            skillDatabase.Add("backStep", new Skill
            {
                SkillName = "백스텝", 
                Type = SkillType.Combat,
                Description = "적의 배후에 치명적인 일격을 가합니다.",
                MpCost = 25
            });

            skillDatabase.Add("IronDefense", new Skill
            {
                SkillName = "철벽", 
                Type = SkillType.Combat,
                Description = "일시적으로 방어력을 크게 증가시킵니다.",
                MpCost = 10
            });

            skillDatabase.Add("shadowDance", new Skill
            {
                SkillName = "그림자 이동", 
                Type = SkillType.Combat,
                Description = "빠르게 움직여 적의 공격을 회피합니다.",
                MpCost = 12
            });

            skillDatabase.Add("Desperate", new Skill
            {
                SkillName = "발악", 
                Type = SkillType.Combat,
                Description = "체력이 낮을수록 강력한 일격을 가합니다.",
                MpCost = 10
            });

            skillDatabase.Add("doubleStrike", new Skill
            {
                SkillName = "쌍격", 
                Type = SkillType.Combat,
                Description = "연속으로 두 번 공격합니다.",
                MpCost = 15
            });

            skillDatabase.Add("energBolt", new Skill
            {
                SkillName = "에너지 볼트", 
                Type = SkillType.Combat,
                Description = "에너지 화살을 발사하여 적에게 피해를 입힙니다.",
                MpCost = 10
            });

            skillDatabase.Add("Piercing", new Skill
            {
                SkillName = "저격", 
                Type = SkillType.Combat,
                Description = "한 번의 공격으로 적의 방어를 무시하고 큰 피해를 입힙니다.",
                MpCost = 18
            });

            skillDatabase.Add("Glacius", new Skill
            {
                SkillName = "글라시우스", 
                Type = SkillType.Combat,
                Description = "차가운 얼음 마법으로 적을 공격합니다.",
                MpCost = 15
            });
        }

        // 스킬 데이터베이스에서 스킬을 조회하는 메서드
        public static Skill GetSkillFromDB(string skillName)
        {
            _skillDatabase.TryGetValue(skillName, out Skill skill);
            return skill; // 못찾으면 null 반환
        }

        // 스킬 습득 메서드
        public static void LearnSkill(string skillName)
        {
            Skill skillToLearn = GetSkillFromDB(skillName);

            if (skillToLearn == null) return;

            // Key("inCombatHide") 기준으로 중복 확인
            bool alreadyLearned = LearnedSkills.Any(s => s.SkillName == skillToLearn.SkillName);

            if (!alreadyLearned)
            {
                LearnedSkills.Add(skillToLearn);
                // "[알림] 스킬 ["이름"]을(를) 배웠습니다!"
            }
        }

        // 스킬 필터링
        public static List<Skill> GetCombatSkills()
        {
            return LearnedSkills
                .Where(skill => skill.Type == SkillType.Combat)
                .ToList();
        }

        // 특수 스킬 필터링
        public static List<Skill> GetSpecialSkills()
        {
            return LearnedSkills
                .Where(skill => skill.Type == SkillType.Special)
                .ToList();
        }

        public static int ExecuteCombatSkill(Skill skill, stat playerStats)
        {
            if (skill.Type != SkillType.Combat) return 0;

            if (playerStats.Mp < skill.MpCost)
            {
                return 0;
            }

            int result = 0;

            switch (skill.SkillName)
            {
                case "찌르기":
                    result = playerStats.Atk * 2;
                    break;

                case "강타":
                    result = playerStats.Atk * 4;
                    break;

                case "은신":
                    result = 0; // 은신 로직은 전투 매니저가 처리해야 함
                    break;

                case "방패 밀치기":
                    result = playerStats.Atk * 1;
                    break;

                case "파이어볼":
                    result = playerStats.Atk * 3;
                    break;

                case "그림자 이동":
                    result = 0; // 회피 로직은 전투 매니저가 처리해야 함
                    break;

                case "백스텝":
                    result = playerStats.Atk * 7;
                    break;

                case "발악":
                    if (playerStats.Hp < (playerStats.MaxHp / 4))
                    {
                        result = playerStats.Atk * 5;
                    }
                    else
                    {
                        result = playerStats.Atk * 1;
                    }
                    break;

                case "철벽":
                    result = 0; // 데미지 감소 로직은 전투 매니저가 처리해야 함
                    break;

                case "쌍격":
                    result = playerStats.Atk * 2; // 2회 공격은 전투 매니저가 처리해야 함
                    break;

                case "에너지 볼트":
                    result = playerStats.Atk * 2;
                    break;

                case "저격":
                    result = playerStats.Atk * 4;
                    break;

                case "글라시우스":
                    result = playerStats.Atk * 3;
                    break;

                case "힐":
                    result += 50; 
                    break;

                default:
                    result = 0; // 알 수 없는 스킬
                    break;
            }

            return result;
        }

        public static string ExecuteSpecialSkill(Skill skill, stat playerStats)
        {
            if (skill.Type != SkillType.Special) return string.Empty;

            if (playerStats.Mp < skill.MpCost)
            {
                return "MP가 부족하여 스킬을 사용할 수 없습니다.";
            }

            string resultMessage = "";

            //switch의 case를 SkillName(한글)으로 수정
            switch (skill.SkillName)
            {
                case "함정 탐지":
                    resultMessage = "주변에서 함정의 기운이 느껴집니다.";
                    break;

                case "은신":
                    resultMessage = "당신은 주변 환경에 몸을 숨겼습니다.";
                    break;

                case "이단 점프":
                    resultMessage = "당신은 이단 점프를 사용하여 더 높이 뛰었습니다.";
                    break;

                case "사다리 설치":
                    resultMessage = "당신은 사다리를 설치했습니다.";
                    break;

                case "힐":
                    resultMessage = "당신은 힐 스킬을 사용하여 체력을 회복했습니다.";
                    break;

                default:
                    resultMessage = "아무 일도 일어나지 않았습니다.";
                    break;
            }

            return resultMessage;
        }
    }
}