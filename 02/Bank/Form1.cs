using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bank
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // ע���¼��������
            Account account = new SavingsAccount("123456", "A", 100000);
            txtAccountNumber.Text = "123456";
            txtAccountHolder.Text = "A";
            txtBalance.Text = "100000";
            account.BigMoneyFetched += Account_BigMoneyFetched;
        }
        // �¼��������
        private void Account_BigMoneyFetched(object sender, BigMoneyArgs e)
        {
            MessageBox.Show($"Big money fetched! Account: {e.Account.AccountHolder}, Amount: {e.WithdrawalAmount}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            // ģ���û�ȡ��
            Random random = new Random();
            
            Account account = new SavingsAccount("123456", "A", 100000);

            try
            {
                // ģ�⻵����Ϊ30%
                if (random.NextDouble() < 0.3)
                {
                    throw new BadCashException("Bad cash detected!");
                }
                
                // ����ȡ��
                decimal withdrawalAmount = Convert.ToDecimal(txtWithdrawalAmount.Text);
                account.Withdraw(withdrawalAmount);

                // ȡ��ɹ���ʾ
                MessageBox.Show($"Withdrawal successful! Amount: {withdrawalAmount}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ���������ʾ
                txtBalance.Text = account.balance.ToString();
            }
            catch (BadCashException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Withdrawal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Withdrawal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

    // �˺���
    public class Account
    {
        public string AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public decimal balance;
        
        public Account(string accountNumber, string accountHolder, decimal balance)
        {
            this.AccountNumber = accountNumber;
            this.AccountHolder = accountHolder;
            this.balance = balance;
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount > balance)
            {
                throw new InvalidOperationException("Insufficient funds");
            }

            balance -= amount;

            // �����¼�
            if (amount > 10000)
            {
                OnBigMoneyFetched(new BigMoneyArgs(this, amount));
            }
        }

        // �����¼���ί��
        public event EventHandler<BigMoneyArgs> BigMoneyFetched;

        protected virtual void OnBigMoneyFetched(BigMoneyArgs e)
        {
            BigMoneyFetched?.Invoke(this, e);
        }
    }

    // �����˺��ࣨ�̳����˺��ࣩ
    public class SavingsAccount : Account
    {
        public decimal CreditLimit { get; set; }

        public SavingsAccount(string accountNumber, string accountHolder, decimal balance)
            : base(accountNumber, accountHolder, balance)
        {
            CreditLimit = 0;
        }

        // ���Ǹ���ķ���
        public override void Withdraw(decimal amount)
        {
            if (amount > balance + CreditLimit)
            {
                throw new InvalidOperationException("Insufficient funds and credit limit exceeded");
            }

            balance -= amount;

            // �����¼�
            if (amount > 10000)
            {
                OnBigMoneyFetched(new BigMoneyArgs(this, amount));
            }
        }
    }

    // �����¼�������
    public class BigMoneyArgs : EventArgs
    {
        public Account Account { get; }
        public decimal WithdrawalAmount { get; }

        public BigMoneyArgs(Account account, decimal withdrawalAmount)
        {
            Account = account;
            WithdrawalAmount = withdrawalAmount;
        }
    }


    // �Զ����쳣��
    public class BadCashException : Exception
    {
        public BadCashException(string message) : base(message)
        {
        }
    }
}
