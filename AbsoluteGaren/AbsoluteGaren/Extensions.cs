using System;
using System.Collections.Generic;
using System.Linq;
using Color = System.Drawing.Color;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace AbsoluteGaren
{
    static class Extensions
    {
        #region Count
        /// <summary>
        /// Returns the amount of specified units in a desired range.
        /// </summary>
        public static float CountUnitsInRange(this Obj_AI_Base sender, List<Obj_AI_Base> units, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return units.Count(a => a.IsValidTarget() && sender.IsInRange(a, range));
        }

        /// <summary>
        /// Returns the amount of specified units in a desired range with Prediction.
        /// </summary>
        public static float CountUnitsInRangeWithPrediction(this Obj_AI_Base sender, List<Obj_AI_Base> units, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return units.Count(a => a.IsValidTarget()
                    && sender.IsInRange(a.PredictedPositionInTime(delay), range));
        }

        /// <summary>
        /// Returns the amount of champions in a desired range.
        /// </summary>
        public static float CountChampionsInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.Heroes.AllHeroes.ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of champions in a desired range with Prediction.
        /// </summary>
        public static float CountChampionsInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.Heroes.AllHeroes.ToObj_AI_BaseList(), range, delay);
        }

        /// <summary>
        /// Returns the amount of minions in a desired range.
        /// </summary>
        public static float CountMinionsInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.MinionsAndMonsters.Minions.ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of minions in a desired range with Prediction.
        /// </summary>
        public static float CountMinionsInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.MinionsAndMonsters.Minions.ToObj_AI_BaseList(), range, delay);
        }

        /// <summary>
        /// Returns the amount of neutral targets in a desired range.
        /// </summary>
        public static float CountNeutralsInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.MinionsAndMonsters.EnemyMinions
                .Concat(EntityManager.MinionsAndMonsters.OtherEnemyMinions)
                .Concat(EntityManager.MinionsAndMonsters.Monsters).ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of neutral targets in a desired range with Prediction.
        /// </summary>
        public static float CountNeutralsInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.MinionsAndMonsters.EnemyMinions
                .Concat(EntityManager.MinionsAndMonsters.OtherEnemyMinions)
                .Concat(EntityManager.MinionsAndMonsters.Monsters).ToObj_AI_BaseList(), range, delay);
        }

        /// <summary>
        /// Returns the amount of jungle creatures in a desired range.
        /// </summary>
        public static float CountMonstersInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.MinionsAndMonsters.Monsters.ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of jungle creatures in a desired range with Prediction.
        /// </summary>
        public static float CountMonstersInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.MinionsAndMonsters.Monsters.ToObj_AI_BaseList(), range, delay);
        }

        /// <summary>
        /// Returns the amount of large jungle creatures in a desired range.
        /// </summary>
        public static float CountLargeMonsterInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.MinionsAndMonsters.Monsters
                .Where(a => a.IsLargeMonster()).ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of large jungle creatures in a desired range with Prediction.
        /// </summary>
        public static float CountLargeMonsterInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.MinionsAndMonsters.Monsters
                .Where(a => a.IsLargeMonster()).ToObj_AI_BaseList(), range, delay);
        }

        /// <summary>
        /// Returns the amount of epic jungle creatures in a desired range.
        /// </summary>
        public static float CountEpicMonsterInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.MinionsAndMonsters.Monsters
                .Where(a => a.IsEpicMonster()).ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of epic jungle creatures in a desired range with Prediction.
        /// </summary>
        public static float CountEpicMonsterInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.MinionsAndMonsters.Monsters
                .Where(a => a.IsEpicMonster()).ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of turret structures in a desired range.
        /// </summary>
        public static float CountTurretsInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.Turrets.AllTurrets.ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of turret structures in a desired range with Prediction.
        /// </summary>
        public static float CountTurretsInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.Turrets.AllTurrets.ToObj_AI_BaseList(), range, delay);
        }

        /// <summary>
        /// Returns the amount of friendly turret structures in a desired range.
        /// </summary>
        public static float CountAllyTurretsInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.Turrets.Allies.ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of friendly turret structures in a desired range with Prediction.
        /// </summary>
        public static float CountAllyTurretsInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.Turrets.Allies.ToObj_AI_BaseList(), range, delay);
        }

        /// <summary>
        /// Returns the amount of enemy turret structures in a desired range.
        /// </summary>
        public static float CountEnemyTurretsInRange(this Obj_AI_Base sender, float range)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRange(EntityManager.Turrets.Enemies.ToObj_AI_BaseList(), range);
        }

        /// <summary>
        /// Returns the amount of enemy turret structures in a desired range with Prediction.
        /// </summary>
        public static float CountEnemyTurretsInRangeWithPrediction(this Obj_AI_Base sender, float range, int delay = 250)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.CountUnitsInRangeWithPrediction(EntityManager.Turrets.Enemies.ToObj_AI_BaseList(), range, delay);
        }

        #endregion

        #region Calculations
        /// <summary>
        /// Calculates if target can be killed with a basic attack.
        /// </summary>
        public static bool CanKillWithBasicAttack(this Obj_AI_Base sender, Obj_AI_Base target)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");
            if (target.IsNull())
                throw new ArgumentNullException("target");

            return Prediction.Health.GetPrediction(target,
                (int)((sender.AttackCastDelay + (target.Distance(sender) / sender.BasicAttack.MissileSpeed)) * 1000))
                <= sender.GetAutoAttackDamage(target);
        }

        /// <summary>
        /// Returns the amount of active item calculated damage.
        /// </summary>
        public static float GetActiveItemDamage(this AIHeroClient sender, Obj_AI_Base target)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");
            if (target.IsNull())
                throw new ArgumentNullException("target");

            float damage = 0;
            List<ItemId> itemList = new List<ItemId>
            {
                ItemId.Bilgewater_Cutlass,
                ItemId.Blade_of_the_Ruined_King,
                ItemId.Hextech_Gunblade,
                ItemId.Hextech_Protobelt_01,
                ItemId.Hextech_GLP_800,
                ItemId.Redemption,
                ItemId.Ravenous_Hydra,
                ItemId.Titanic_Hydra,
                ItemId.Tiamat
            };

            // Items with same unique active abilities
            bool hasTiamat = sender.InventoryItems.Any(a => a.Id == ItemId.Tiamat) ? true : false;
            bool hasRavenousHydra = sender.InventoryItems.Any(a => a.Id == ItemId.Ravenous_Hydra) ? true : false;
            bool hasTitanicHydra = sender.InventoryItems.Any(a => a.Id == ItemId.Titanic_Hydra) ? true : false;

            foreach (ItemId id in itemList)
            {
                InventorySlot item = sender.InventoryItems.FirstOrDefault(a => a.Id == id);

                if (item != null && item.CanUseItem() && target.IsValidTarget()
                    && item.Id != ItemId.Redemption)
                    damage += sender.GetItemDamage(target, id);
                if (item != null && item.CanUseItem() && target.IsValidTarget()
                    && item.Id == ItemId.Redemption)
                    damage += target.PercentMaximumHealth(10);
            }

            return damage;
        }

        /// <summary>
        /// Returns the amount of active item calculated healing.
        /// </summary>
        public static float GetActiveItemHealing(this AIHeroClient sender, Obj_AI_Base target = null)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            float healing = 0;
            List<ItemId> itemList = new List<ItemId>
            {
                ItemId.Blade_of_the_Ruined_King,
                ItemId.Hextech_Gunblade,
                ItemId.Redemption,
            };

            foreach (ItemId id in itemList)
            {
                InventorySlot item = sender.InventoryItems.FirstOrDefault(a => a.Id == id);

                if (item != null && item.CanUseItem())
                {
                    if (item.Id.Equals(ItemId.Blade_of_the_Ruined_King)
                        && target != null && target.IsValidTarget())
                        healing += sender.GetItemDamage(target, id);
                    if (item.Id.Equals(ItemId.Hextech_Gunblade))
                        healing += 0.15f * (171 + (4 * Player.Instance.Level) + Player.Instance.PercentAbilityPower(30));
                    if (item.Id.Equals(ItemId.Redemption))
                        healing += 40 + (25 * sender.Level);
                }
            }

            if (sender.HasItem(ItemId.Spirit_Visage))
                healing *= 1.25f;

            return healing;
        }

        /// <summary>
        /// Returns the predicted position a unit is traveling to in time.
        /// </summary>
        public static Vector3 PredictedPositionInTime(this Obj_AI_Base sender, int time)
        {
            Vector3 pos = Prediction.Position.PredictUnitPosition(sender, time).To3D(0);

            return new Vector3(pos.X, pos.Y, NavMesh.GetHeightForPosition(pos.X, pos.Y));
        }
        #endregion

        #region Menu
        /// <summary>
        /// Generates a Checkbox to a specified Menu object.
        /// </summary>
        public static void AddCheckBox(this Menu sender, string uniqueIdentifier, string displayName, bool defaultValue = true)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            sender.Add(uniqueIdentifier, new CheckBox(displayName, defaultValue));
        }

        /// <summary>
        /// Returns a CheckBox object with a unique identifier.
        /// </summary>
        public static CheckBox GetCheckBoxObject(this Menu sender, string uniqueIdentifier)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (sender.Get<CheckBox>(uniqueIdentifier) != null)
                return sender.Get<CheckBox>(uniqueIdentifier);
            else
                Console.WriteLine("CheckBox with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");

            return null;
        }

        /// <summary>
        /// Returns the current value of a CheckBox object with a unique identifier.
        /// </summary>
        public static bool GetCheckBoxValue(this Menu sender, string uniqueIdentifier)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (sender.GetCheckBoxObject(uniqueIdentifier) != null)
                return sender.GetCheckBoxObject(uniqueIdentifier).CurrentValue;
            else
                Console.WriteLine("CheckBox with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");

            return false;
        }

        /// <summary>
        /// Generates a Slider to a specified Menu object.
        /// </summary>
        public static void AddSlider(this Menu sender, string uniqueIdentifier, string displayName,
            int defaultValue = 0, int minValue = 0, int maxValue = 100)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            sender.Add(uniqueIdentifier, new Slider(displayName, defaultValue, minValue, maxValue));
        }

        /// <summary>
        /// Returns a Slider object with a unique identifier.
        /// </summary>
        public static Slider GetSliderObject(this Menu sender, string uniqueIdentifier)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (sender.Get<Slider>(uniqueIdentifier) != null)
                return sender.Get<Slider>(uniqueIdentifier);
            else
                Console.WriteLine("Slider with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");

            return null;
        }

        /// <summary>
        /// Returns the current value of a Slider object with a unique identifier.
        /// </summary>
        public static int GetSliderValue(this Menu sender, string uniqueIdentifier)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (sender.GetSliderObject(uniqueIdentifier) != null)
                return sender.GetSliderObject(uniqueIdentifier).CurrentValue;
            else
                Console.WriteLine("Slider with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");

            return -1;
        }

        /// <summary>
        /// Generates a ComboBox to a specified Menu object.
        /// </summary>
        public static void AddComboBox(this Menu sender, string uniqueIdentifier, string displayName,
            List<string> textValues, int defaultIndex)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            sender.Add(uniqueIdentifier, new ComboBox(displayName, textValues, defaultIndex));
        }

        /// <summary>
        /// Returns a ComboBox object with a unique identifier.
        /// </summary>
        public static ComboBox GetComboBoxObject(this Menu sender, string uniqueIdentifier)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (sender.Get<ComboBox>(uniqueIdentifier) != null)
                return sender.Get<ComboBox>(uniqueIdentifier);
            else
                Console.WriteLine("ComboBox with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");

            return null;
        }

        /// <summary>
        /// Returns the selected index of a ComboBox object with a unique identifier.
        /// </summary>
        public static int GetComboBoxSelectedIndex(this Menu sender, string uniqueIdentifier)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (sender.GetComboBoxObject(uniqueIdentifier) != null)
                return sender.GetComboBoxObject(uniqueIdentifier).SelectedIndex;
            else
                Console.WriteLine("ComboBox with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");

            return -1;
        }

        /// <summary>
        /// Returns the selected text of a ComboBox object with a unique identifier.
        /// </summary>
        public static string GetComboBoxSelectedText(this Menu sender, string uniqueIdentifier)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (sender.GetComboBoxObject(uniqueIdentifier) != null)
                return sender.GetComboBoxObject(uniqueIdentifier).SelectedText;
            else
                Console.WriteLine("ComboBox with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");

            return null;
        }

        /// <summary>
        /// Generates a KeyBind to a specified Menu object.
        /// </summary>
        public static void AddKeyBind(this Menu sender, string uniqueIdentifier, string displayName,
            bool defaultValue, KeyBind.BindTypes bindTypes, char default1, char default2)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            sender.Add(uniqueIdentifier, new KeyBind(displayName, defaultValue, bindTypes, default1, default2));
        }

        /// <summary>
        /// Returns a KeyBind object with a unique identifier.
        /// </summary>
        public static KeyBind GetKeyBindObject(this Menu sender, string uniqueIdentifier)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (sender.Get<KeyBind>(uniqueIdentifier) != null)
                return sender.Get<KeyBind>(uniqueIdentifier);
            else
                Console.WriteLine("KeyBind with id - " + uniqueIdentifier + " - isn't initialized in " + sender + ".");

            return null;
        }
        #endregion

        #region Prediction
        public static Vector3 BestConeCastPosition(this Spell.Skillshot cone, List<Obj_AI_Base> enemies, out int bestHitNumber)
        {
            int radius = (int)cone.Range;

            enemies = enemies.Where(a => a.IsValidTarget() && a.PredictedPositionInTime(cone.CastDelay).IsInRange(Player.Instance.Position, radius)).ToList();

            bestHitNumber = 0;
            Vector3 castPosition = Vector3.Zero;

            //if there is nothing that meets the criteria
            if (enemies.Count() == 0)
                return castPosition;

            List<Tuple<Geometry.Polygon.Sector, Vector3>> conePositions = new List<Tuple<Geometry.Polygon.Sector, Vector3>>();

            Vector3 extendingPosition = Player.Instance.Position + new Vector3(0, radius, 0);

            //checks every 15 degrees
            for (int i = 0; i < 24; i++)
            {
                Vector3 endPosition = extendingPosition.To2D().RotateAroundPoint(Player.Instance.Position.To2D(),
                    (float)((i * 15) * Math.PI / 180)).To3D((int)Player.Instance.Position.Z);
                Geometry.Polygon.Sector sector = new Geometry.Polygon.Sector(Player.Instance.Position,
                     endPosition, (float)(cone.ConeAngleDegrees * Math.PI / 180), radius);

                conePositions.Add(Tuple.Create(sector, endPosition));
            }

            //from the ones with the most sector/line enemies hit AND the most line enemies hit, find the ones with the most sector area
            conePositions = conePositions.Where(a => a.Item1.GetEnemiesHitInSector(enemies, cone.CastDelay).Count > 0)
                .OrderByDescending(a => a.Item1.EnemiesHitInSector(enemies, cone.CastDelay))
                .ThenBy(a => a.Item1.GetEnemiesHitInSector(enemies, cone.CastDelay)[0].Distance(a.Item1.Points[a.Item1.Points.Count / 2]))
                .ToList();

            Tuple<Geometry.Polygon.Sector, Vector3> bestCone = conePositions.First();

            bestHitNumber = bestCone.Item1.EnemiesHitInSector(enemies, cone.CastDelay);

            return Player.Instance.Position.Extend(bestCone.Item2, radius - 1).To3D((int)Player.Instance.Position.Z);
        }

        public static Tuple<Vector3, Vector3> DirectionInTime(this Obj_AI_Base self, float time)
        {
            if (!self.IsMoving || self.Path.Last().IsInRange(self.Position, 1))
                return new Tuple<Vector3, Vector3> (self.Direction, self.Position);

            float speed = self.MoveSpeed,
                totalUnitsTraveled = time * speed;

            float unitsLeft = totalUnitsTraveled;
            for (int i = 0; i < self.Path.Count() - 1; i++)
            {
                float distBetweenLine = self.Path[i].Distance(self.Path[i + 1]);
                if (distBetweenLine <= unitsLeft)
                    unitsLeft -= distBetweenLine;
                else
                    return new Tuple<Vector3, Vector3>(- (self.Path[i] - self.Path[i + 1]).Normalized(), self.Path[i]);
            }
            return new Tuple<Vector3, Vector3> ((self.Path[self.Path.Count() - 1] - self.Path.Last()).Normalized(), self.Path.Last());
        }

        public static bool IsFacingInTime(this Obj_AI_Base self, Vector3 positionToCompare, float time, int angleInDegrees)
        {
            Tuple<Vector3, Vector3> directionInTime = self.DirectionInTime(time);

            if (directionInTime.Item1.IsZero || directionInTime.Item2.IsZero)
                return false;

            return !self.IsNull() && self.IsValid
                && directionInTime.Item1.To2D().AngleBetween((positionToCompare - directionInTime.Item2).To2D()) < angleInDegrees / 2;
        }

        public static bool IsFacingInTime(this Obj_AI_Base self, Obj_AI_Base unit, float time, int angleInDegrees)
        {
            return self.IsFacingInTime(unit.PredictedPositionInTime((int)time * 1000), time, angleInDegrees);
        }

        public static int EnemiesHitInSector(this Geometry.Polygon.Sector sector, List<Obj_AI_Base> enemies, int delay)
        {
            return enemies.Where(a => a.IsValidTarget() && sector.IsInside(a.PredictedPositionInTime(delay))).Count();
        }

        public static List<Obj_AI_Base> GetEnemiesHitInSector(this Geometry.Polygon.Sector sector, List<Obj_AI_Base> enemies, int delay)
        {
            return enemies.Where(a => a.IsValidTarget() && sector.IsInside(a.PredictedPositionInTime(delay))).ToList();
        }

        public static List<Obj_AI_Base> GetUnitsHitBySpell(this Spell.Skillshot.BestPosition bestpos, Spell.Skillshot spell, List<Obj_AI_Base> enemies)
        {
            List<Obj_AI_Base> units = new List<Obj_AI_Base>();
            Geometry.Polygon shape = new Geometry.Polygon();

            if (spell.Type == SkillShotType.Circular)
                shape = new Geometry.Polygon.Circle(bestpos.CastPosition, spell.Radius);
            else if (spell.Type == SkillShotType.Cone)
            {
                shape = new Geometry.Polygon.Arc(Player.Instance.Position, bestpos.CastPosition,
                    MathUtil.DegreesToRadians(spell.ConeAngleDegrees), spell.Radius);
            }

            foreach (Obj_AI_Base o in enemies)
                if (shape.IsInside(o.PredictedPositionInTime(spell.CastDelay)))
                    units.Add(o);

            return units;
        }
        #endregion

        #region Rendering
        /// <summary>
        /// Used to graphically render over a unit's Health Bar.
        /// </summary>
        public static void RenderHPBar(this Obj_AI_Base sender, float amount)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            float unitHPBarWidth = 96;
            float unitHPBarAmount = 0;
            Vector2 unitHPBarOffset = Vector2.Zero;
            Vector2 unitHPCurrentOffset = Vector2.Zero;
            Vector2 unitHPEndOffset = Vector2.Zero;
            Color color = Color.White;

            if (sender.IsEnemy)
            {
                unitHPBarAmount = Math.Max((100 * ((sender.Health - amount) / sender.MaxHealth)), 0);
                unitHPBarOffset = new Vector2(sender.HPBarXOffset + 3f, sender.HPBarYOffset + 9.2f);
                unitHPCurrentOffset = sender.HPBarPosition + unitHPBarOffset
                    + new Vector2(100 * sender.HealthPercent / unitHPBarWidth, 0);
                unitHPEndOffset = sender.HPBarPosition + unitHPBarOffset
                    + new Vector2(unitHPBarAmount, 0);
                color = Color.DarkRed;
            }
            else
            {
                unitHPBarAmount = Math.Min(100 * (sender.Health + amount) / sender.MaxHealth, 100);
                unitHPBarOffset = new Vector2(sender.HPBarXOffset + 23f, sender.HPBarYOffset + 7f);
                unitHPCurrentOffset = sender.HPBarPosition + unitHPBarOffset
                    + new Vector2(100 * sender.HealthPercent / unitHPBarWidth, 0);
                unitHPEndOffset = sender.HPBarPosition + unitHPBarOffset
                    + new Vector2(100 * unitHPBarAmount / unitHPBarWidth, 0);
                color = Color.YellowGreen;
            }

            Drawing.DrawLine(unitHPCurrentOffset, unitHPEndOffset, 9, color);
        }
        #endregion

        #region Spells
        /// <summary>
        /// Returns the amount of ability power for a specified unit.
        /// </summary>
        public static float AbilityPower(this Obj_AI_Base sender)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.FlatMagicDamageMod;
        }

        /// <summary>
        /// Returns the amount of attack damage for a specified unit.
        /// </summary>
        public static float AttackDamage(this Obj_AI_Base sender)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.FlatPhysicalDamageMod;
        }
        
        /// <summary>
        /// Returns the amount of missing health for a specified unit.
        /// </summary>
        public static float MissingHealth(this Obj_AI_Base sender)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return (sender.MaxHealth - sender.Health);
        }
        
        /// <summary>
        /// Returns the percentage of ability power for a specified unit.
        /// </summary>
        public static float PercentAbilityPower(this Obj_AI_Base sender, float percent)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return (percent / 100) * sender.FlatMagicDamageMod;
        }
        
        /// <summary>
        /// Returns the percentage of bonus ability power for a specified unit.
        /// </summary>
        public static float PercentBonusAbilityPower(this Obj_AI_Base sender, float percent)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return (percent / 100) * (sender.TotalMagicalDamage - sender.BaseAbilityDamage);
        }

        /// <summary>
        /// Returns the percentage of attack damage for a specified unit.
        /// </summary>
        public static float PercentAttackDamage(this Obj_AI_Base sender, float percent)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return (percent / 100) * sender.FlatPhysicalDamageMod;
        }
        
        /// <summary>
        /// Returns the percentage of bonus attack damage for a specified unit.
        /// </summary>
        public static float PercentBonusAttackDamage(this Obj_AI_Base sender, float percent)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return (percent / 100) * (sender.TotalAttackDamage - sender.BaseAttackDamage);
        }
        
        /// <summary>
        /// Returns the percentage of maximum health for a specified unit.
        /// </summary>
        public static float PercentMaximumHealth(this Obj_AI_Base sender, float percent)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return (percent * 100) * sender.MaxHealth;
        }
        
        /// <summary>
        /// Returns the percentage of missing health for a specified unit.
        /// </summary>
        public static float PercentMissingHealth(this Obj_AI_Base sender, float percent)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return sender.MissingHealth() / sender.MaxHealth;
        }

        /// <summary>
        /// Returns the sight range to fog of war for a specified hero unit.
        /// </summary>
        public static float ViewRange(this AIHeroClient sender)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            return 1200;
        }
        #endregion

        #region Verifications
        /// <summary>
        /// Verify an AIHeroClient object's Champion attribute.
        /// </summary>
        public static bool VerifyHero(this AIHeroClient sender, Champion check)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");

            if (sender.Hero != check)
            {
                Console.WriteLine(sender.Hero + "isn't compatible with this Addon.");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Returns true if object identifies as a large monster.
        /// </summary>
        public static bool IsLargeMonster(this Obj_AI_Base sender)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");
            
            List<string> list = new List<string> { "SRU_Red", "SRU_Blue",
            "SRU_Murkwolf", "SRU_Razorbeak", "SRU_Krug", "SRU_KrugMini", "SRU_Gromp", "Sru_Crab",
            "SRU_Dragon_Air", "SRU_Dragon_Fire", "SRU_Dragon_Water", "SRU_Dragon_Earth",
            "SRU_Dragon_Elder", "SRU_RiftHerald", "SRU_Baron",
            "TT_NWraith", "TT_NGolem", "TT_NWolf", "TT_Spiderboss" };

            return list.Contains(sender.BaseSkinName);
        }

        /// <summary>
        /// Returns true if object isn't set to an instance.
        /// </summary>
        public static bool IsNull(this Obj_AI_Base sender)
        {
            return sender == null;
        }

        /// <summary>
        /// Returns true if object identifies as an objective monster.
        /// </summary>
        public static bool IsEpicMonster(this Obj_AI_Base sender)
        {
            if (sender.IsNull())
                throw new ArgumentNullException("sender");
            
            List<string> list = new List<string> { "SRU_Dragon_Elder",
                "SRU_Dragon_Air", "SRU_Dragon_Fire", "SRU_Dragon_Water", "SRU_Dragon_Earth",
                "SRU_Dragon_Elder", "SRU_RiftHerald", "SRU_Baron", "TT_Spiderboss" };

            return list.Contains(sender.BaseSkinName);
        }

        public static bool IsWithinTime(this float startTime, float duration)
        {
            return (Game.Time - startTime) < duration;
        }
        #endregion
    }
}
