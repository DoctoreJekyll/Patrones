using System;
using Input;
using Ships.CheckLimits;
using Ships.Enemies;
using UnityEngine;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;

namespace Ships.Common
{
    public class ShipBuilder
    {
        public enum InputMode
        {
            Unity,
            Joystick,
            Ai
        }

        public enum CheckLimitTypes
        {
            InitialPosition,
            Viewport
        }

        private ShipMediator prefab;
        private Vector3 position = Vector3.zero;
        private Quaternion rotation = Quaternion.identity;
        private Input.Input input;
        private CheckLimits.CheckLimits checkLimits;
        private ShipToSpawnConfiguration shipConfiguration;
        private InputMode inputMode;
        private Joystick joystick;
        private JoyButton joyButton;
        private CheckLimitTypes checkLimitType;

        public ShipBuilder FromPrefab(ShipMediator prefab)
        {
            this.prefab = prefab;
            return this;
        }

        public ShipBuilder WithPosition(Vector3 position)
        {
            this.position = position;
            return this;
        }

        public ShipBuilder WithRotation(Quaternion rotation)
        {
            this.rotation = rotation;
            return this;
        }

        public ShipBuilder WithInput(Input.Input input)
        {
            this.input = input;
            return this;
        }

        public ShipBuilder WithCheckLimits(CheckLimits.CheckLimits checkLimits)
        {
            this.checkLimits = checkLimits;
            return this;
        }

        public ShipBuilder WithConfiguration(ShipToSpawnConfiguration shipConfiguration)
        {
            this.shipConfiguration = shipConfiguration;
            return this;
        }

        public ShipBuilder WithInputMode(InputMode inputMode)
        {
            this.inputMode = inputMode;
            return this;
        }

        public ShipBuilder WithJoysticks(Joystick joystick, JoyButton joyButton)
        {
            this.joystick = joystick;
            this.joyButton = joyButton;
            return this;
        }

        public ShipBuilder WithCheckLimitType(CheckLimitTypes type)
        {
            checkLimitType = type;
            return this;
        }


        private CheckLimits.CheckLimits GetCheckLimits(ShipMediator ship)
        {
            if (checkLimits != null)
            {
                return checkLimits;
            }

            switch (checkLimitType)
            {
                case CheckLimitTypes.InitialPosition:
                    return new InitialPositionCheckLimits(ship.transform, 10);
                case CheckLimitTypes.Viewport:
                    return new ViewportCheckLimits(ship.transform, Camera.main);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private Input.Input GetInput(ShipMediator shipMediator)
        {
            if (input != null)
            {
                return input;
            }

            switch (inputMode)
            {
                case InputMode.Unity:
                    return new UnityInputAdapter();
                case InputMode.Joystick:
                    Assert.IsNotNull(joystick);
                    Assert.IsNotNull(joyButton);
                    return new JoystickInputAdapter(joystick, joyButton);
                case InputMode.Ai:
                    return new AIInputAdapter(shipMediator);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public ShipMediator Build()
        {
            var ship = Object.Instantiate(prefab, position, rotation);
            var configuration = new ShipConfiguration(GetInput(ship),
                                                          GetCheckLimits(ship),
                                                          this.shipConfiguration.Speed,
                                                          this.shipConfiguration.FireRate,
                                                          this.shipConfiguration.DefaultProjectileId);
            ship.Configure(configuration);
            return ship;
        }
    }
}
