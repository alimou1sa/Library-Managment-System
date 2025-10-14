
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Library_DataAccessLayer;


namespace Library_Business
{

    public class clsPaymentDetails : clsPayments
    {

        public enum enMode { AddNew, Update };

        public enMode _Mode;

        public int PaymentDetailID { set; get; }
        public int EntityTypeID { set; get; }
        public int EntityID { set; get; }

        public clsPaymentEntities PaymentEntitiesInfo { set; get; }
        public clsUsers UsersInfo { set; get; }
        public clsPaymentTypes PaymentTypesInfo { set; get; }



        public clsPaymentDetails()
        {
            this._Mode = enMode.AddNew;
            this.PaymentDetailID = -1;
            this.PaymentID = -1;
            this.EntityTypeID = -1;
            this.EntityID = -1;

            this.PaymentEntitiesInfo = null;
        }

        private clsPaymentDetails(int PaymentDetailID, int PaymentID, int EntityTypeID, int EntityID,
            int PaymentTypeID, int MemberID, double Amount, byte PaymentStatus, int CreateByUserID, DateTime PaymentDate)
        {
            this._Mode = enMode.Update;

            this.PaymentDetailID = PaymentDetailID;
            this.PaymentID = PaymentID;
            this.EntityTypeID = EntityTypeID;
            this.EntityID = EntityID;
            this.PaymentID = PaymentID;
            this.PaymentTypeID = PaymentTypeID;
            this.MemberID = MemberID;
            this.Amount = Amount;
            this.PaymentStatus = PaymentStatus;
            this.CreateByUserID = CreateByUserID;
            this.PaymentDate = PaymentDate;

            this.PaymentEntitiesInfo = clsPaymentEntities.FindByID(EntityTypeID);
            this.UsersInfo = clsUsers.FindByUserID(CreateByUserID);
            this.PaymentTypesInfo = clsPaymentTypes.FindByID(PaymentTypeID);

        }

        public static clsPaymentDetails FindByEntityID(int EntityID, int EntityTypeID)
        {
            int PaymentID = -1;
            int PaymentDetailID = -1;
            int PaymentTypeID = -1;
            int MemberID = -1;
            int Amount = -1;
            byte PaymentStatus = 0;
            int CreateByUserID = -1;
            DateTime PaymentDate = DateTime.Now;

            if (clsPaymentDetailsDataAccess.GetPaymentDetailsInfoByEntityID(EntityID, EntityTypeID, ref PaymentDetailID, ref PaymentID))
            {


                clsPayments payments = clsPayments.FindByID(PaymentID);

                return new clsPaymentDetails(PaymentDetailID, PaymentID, EntityTypeID, EntityID, payments.PaymentTypeID,
                    payments.MemberID, payments.Amount, payments.PaymentStatus, payments.CreateByUserID, payments.PaymentDate);

            }

            return null;
        }

        public static clsPaymentDetails FindByID(int PaymentDetailID)
        {
            int PaymentID = -1;
            int EntityTypeID = -1;
            int EntityID = -1;
            DateTime PaymentDate = DateTime.Now;

            if (clsPaymentDetailsDataAccess.GetPaymentDetailsInfoByID(PaymentDetailID,
                ref PaymentID, ref EntityTypeID, ref EntityID)){

                clsPayments payments = clsPayments.FindByID(PaymentID);

                return new clsPaymentDetails(PaymentDetailID, PaymentID, EntityTypeID, EntityID, payments.PaymentTypeID,
                     payments.MemberID, payments.Amount, payments.PaymentStatus, payments.CreateByUserID, payments.PaymentDate);
            }

            return null;
        }
     
        private async Task<bool> _AddNewPaymentDetails()
        {
            this.PaymentDetailID = await clsPaymentDetailsDataAccess.AddNewPaymentDetails(this.PaymentID,
                this.EntityTypeID, this.EntityID);

            return (this.PaymentDetailID != -1);
        }

        private async Task<bool> _UpdatePaymentDetails()
        {
            return await clsPaymentDetailsDataAccess.UpdatePaymentDetails(this.PaymentDetailID, this.PaymentID,
                this.EntityTypeID, this.EntityID);
        }

        public async Task<bool> Save()
        {
            base._Mode = (clsPayments.enMode)_Mode;
            if (!await base.Save())
                return false;

            switch (_Mode)
            {
                case enMode.AddNew:

                    if (await _AddNewPaymentDetails())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:

                    return await _UpdatePaymentDetails();

                default:
                    return false;

            }
        }

        public async Task<bool> Delete()
        {
            bool IsPaymentDetailsDeleted = false;
            bool IsBasePaymentDeleted = false;
            IsPaymentDetailsDeleted = await clsPaymentDetails.DeletePaymentDetails(this.PaymentDetailID);

            if (!IsPaymentDetailsDeleted)
                return false;

            IsBasePaymentDeleted = await base.DeletePayments();
            return IsBasePaymentDeleted;

        }

        public static async Task<bool> DeletePaymentDetails(int PaymentDetailID)
        {
            return await clsPaymentDetailsDataAccess.DeletePaymentDetails(PaymentDetailID);

        }
    
        public static async Task<DataTable> GetListPaymentDetails()
        {

            return await clsPaymentDetailsDataAccess.GetListPaymentDetails();
        }

        public static async Task<bool> IsPaymentDetailsExisteByID(int PaymentDetailID)
        {
            return await clsPaymentDetailsDataAccess.IsPaymentDetailsExisteByID(PaymentDetailID);

        }

        public async Task<clsPaymentDetails> AddPayment(int PaymentTypeID, int CreatByUseID, clsPaymentEntities.enEntityType entityType)
        {
            clsPaymentDetails _PaymentDetails = this;
            _PaymentDetails.PaymentTypeID = PaymentTypeID;
            _PaymentDetails.MemberID = this.MemberID;
            _PaymentDetails.Amount = this.Amount;
            _PaymentDetails.PaymentStatus = (byte)clsPayments.enPaymentStatus.Paid;
            _PaymentDetails.CreateByUserID = CreatByUseID;
            _PaymentDetails.PaymentDate = DateTime.Now;
            int EntityTypeID = (byte)entityType;
            _PaymentDetails.EntityTypeID = clsPaymentEntities.FindByID(EntityTypeID).EntityTypeID;

            if (!await _PaymentDetails.Save())
                return null;

            return _PaymentDetails;
        }

    }
}