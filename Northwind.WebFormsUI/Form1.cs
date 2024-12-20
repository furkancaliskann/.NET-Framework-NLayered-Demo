﻿using Northwid.Business.Abstract;
using Northwid.Business.Concrete;
using Northwid.Business.DependencyResolvers.Ninject;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        IProductService _productService;
        ICategoryService _categoryService;

        public Form1()
        {
            InitializeComponent();
            _productService = InstanceFactory.GetInstance<IProductService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

            cbxCategoryIdAdd.DataSource = _categoryService.GetAll();
            cbxCategoryIdAdd.DisplayMember = "CategoryName";
            cbxCategoryIdAdd.ValueMember = "CategoryId";

            cbxCategoryIdUpdate.DataSource = _categoryService.GetAll();
            cbxCategoryIdUpdate.DisplayMember = "CategoryName";
            cbxCategoryIdUpdate.ValueMember = "CategoryId";
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch
            {

            }
        }

        private void tbxProductName_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbxProductName.Text))
            {
                LoadProducts();
            }
            else
            {
                dgwProduct.DataSource = _productService.GetProductsByProductName(tbxProductName.Text);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Product
                {
                    CategoryId = Convert.ToInt32(cbxCategoryIdAdd.SelectedValue),
                    ProductName = tbxProductNameAdd.Text,
                    QuantityPerUnit = tbxQuantityPerUnitAdd.Text,
                    UnitPrice = Convert.ToDecimal(tbxUnitPriceAdd.Text),
                    UnitsInStock = Convert.ToInt16(tbxStockAmountAdd.Text)
                });

                LoadProducts();
                MessageBox.Show("Ürün Kaydedildi!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {
                ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                CategoryId = Convert.ToInt32(cbxCategoryIdUpdate.SelectedValue),
                ProductName = tbxProductNameUpdate.Text,
                QuantityPerUnit = tbxQuantityPerUnitUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                UnitsInStock = Convert.ToInt16(tbxStockAmountUpdate.Text)
            });

            LoadProducts();
            MessageBox.Show("Ürün Güncellendi!");
        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgwProduct.CurrentRow;
            tbxProductNameUpdate.Text = row.Cells[1].Value.ToString();
            cbxCategoryIdUpdate.SelectedValue = row.Cells[2].Value;
            tbxUnitPriceUpdate.Text = row.Cells[3].Value.ToString();
            tbxQuantityPerUnitUpdate.Text = row.Cells[4].Value.ToString();
            tbxStockAmountUpdate.Text = row.Cells[5].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(dgwProduct.CurrentRow != null)
            {
                try
                {
                    _productService.Delete(new Product { ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value) });

                    LoadProducts();
                    MessageBox.Show("Ürün Silindi!");
                }
                catch(Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    return;
                }
               
            }
            else
            {
                MessageBox.Show("Lütfen Ürün Seçiniz!");
                return;
            }
        }
    }
}
