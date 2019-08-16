using GACore.Architecture;
using NUnit.Framework;

namespace GACore.Test
{
    [TestFixture]
    [Description("Kingpin Fault Diagnosis")]
    public class TKingpinFaultDiagnosis
    {
        [Test]
        public void CheckMotorLostFault()
        {
            KingpinFaultDiagnosis diagnosis = new KingpinFaultDiagnosis(GetMotorLostFault());

            Assert.IsTrue(diagnosis.IsInFault());

            Assert.IsNotNull(diagnosis.DynamicLimiterFault);
            Assert.IsNull(diagnosis.ExtendedDataFault);
            Assert.IsNotNull(diagnosis.NavigationFault);
            Assert.IsNull(diagnosis.PCSFault);

            Assert.AreEqual(diagnosis, GetMotorLostFault().Diagnose());
            Assert.AreNotEqual(diagnosis, GetMotorFault().Diagnose());
            Assert.AreNotEqual(diagnosis, GetNoFaultState().Diagnose());
        }

        [Test]
        public void CheckMotorFault()
        {
            KingpinFaultDiagnosis diagnosis = new KingpinFaultDiagnosis(GetMotorFault());

            Assert.IsTrue(diagnosis.IsInFault());

            Assert.IsNotNull(diagnosis.DynamicLimiterFault);
            Assert.IsNull(diagnosis.ExtendedDataFault);
            Assert.IsNull(diagnosis.NavigationFault);
            Assert.IsNull(diagnosis.PCSFault);

            Assert.AreEqual(diagnosis, GetMotorFault().Diagnose());
            Assert.AreNotEqual(diagnosis, GetNoFaultState());
        }

        [Test]
        public void CheckNoFault()
        {
            KingpinFaultDiagnosis diagnosis = new KingpinFaultDiagnosis(GetNoFaultState());

            Assert.IsFalse(diagnosis.IsInFault());

            Assert.IsNull(diagnosis.DynamicLimiterFault);
            Assert.IsNull(diagnosis.ExtendedDataFault);
            Assert.IsNull(diagnosis.NavigationFault);
            Assert.IsNull(diagnosis.PCSFault);

            Assert.AreEqual(diagnosis, GetNoFaultState().Diagnose());
        }

        private IKingpinState GetNoFaultState()
        {
            return new KingpinStateData()
            {
                DynamicLimiterStatus = DynamicLimiterStatus.OK,
                ExtendedDataFaultStatus = ExtendedDataFaultStatus.OK,
                NavigationStatus = NavigationStatus.OK,
                PositionControlStatus = PositionControlStatus.OK
            };
        }

        private IKingpinState GetMotorLostFault()
        {
            return new KingpinStateData()
            {
                DynamicLimiterStatus = DynamicLimiterStatus.MotorFault,
                ExtendedDataFaultStatus = ExtendedDataFaultStatus.OK,
                NavigationStatus = NavigationStatus.Lost,
                PositionControlStatus = PositionControlStatus.OK
            };
        }

        private IKingpinState GetMotorFault()
        {
            return new KingpinStateData()
            {
                DynamicLimiterStatus = DynamicLimiterStatus.MotorFault,
                ExtendedDataFaultStatus = ExtendedDataFaultStatus.OK,
                NavigationStatus = NavigationStatus.OK,
                PositionControlStatus = PositionControlStatus.OK
            };
        }
    }
}