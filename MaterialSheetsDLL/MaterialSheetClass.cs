/* Title:           Material Sheet Class
 * Date:            7-30-20
 * Author:          Terry Holmes
 * 
 * Description:     This is the material sheet class */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace MaterialSheetsDLL
{
    public class MaterialSheetClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        MaterialSheetTypesDataSet aMaterialSheetTypesDataSet;
        MaterialSheetTypesDataSetTableAdapters.materialsheettypesTableAdapter aMaterialSheetTypesTableAdapter;

        InsertMaterialSheetTypeEntryTableAdapters.QueriesTableAdapter aInsertMaterialSheetTypeTableAdapter;

        FindSortedMaterialSheetTypesDataSet aFindSortedMaterialSheetTypesDataSet;
        FindSortedMaterialSheetTypesDataSetTableAdapters.FindSortedMaterialSheetTypesTableAdapter aFindSortedMaterialSheetTypesTableAdapter;

        FindMaterialSheetTypeBySheetTypeDataSet aFindMaterialSheetTypeBySheetTypeDataSet;
        FindMaterialSheetTypeBySheetTypeDataSetTableAdapters.FindMaterialSheetTypeBySheetTypeTableAdapter aFindMaterialSheetTypeBySheetTypeTableAdapter;

        FindMaterialSheetTypeBySheetTypeIDDataSet aFindMaterialSheetTypeBySheetTypeIDDataSet;
        FindMaterialSheetTypeBySheetTypeIDDataSetTableAdapters.FindMaterialSheetTypeBySheetTypeIDTableAdapter aFindMaterialSheetTypeBySheetTypeIDTableAdapter;

        MaterialSheetsDataSet aMaterialSheetsDataSet;
        MaterialSheetsDataSetTableAdapters.materialsheetsTableAdapter aMaterialSheetTableAdapter;

        InsertMaterialSheetEntryTableAdapters.QueriesTableAdapter aInsertMaterialSheetTableAdapter;

        CreateMaterialSheetDataSet aCreateMaterialSheetDataSet;
        CreateMaterialSheetDataSetTableAdapters.CreateMaterialSheetTableAdapter aCreateMaterialSheetTableAdapter;

        FindMaterialSheetEntryByPartIDSheetIDWarehouseIDDataSet aFindMaterialSheetEntryByPartIDSheetIDWarehouseIDDataSet;
        FindMaterialSheetEntryByPartIDSheetIDWarehouseIDDataSetTableAdapters.FindMaterialSheetEntryByPartIDSheetIDWarehouseIDTableAdapter aFindMaterialSheetEntryByPartIDSheetIDWarehouseIDTableAdapter;

        FindMaterialSheetByPartIDDataSet aFindMaterialSheetByPartIDDataSet;
        FindMaterialSheetByPartIDDataSetTableAdapters.FindMaterialSheetByPartIDTableAdapter aFindMaterialSheetByPartIDTableAdapter;

        FindMaterialSheetsByEmployeeIDDataSet aFindMaterialSheetsByEmployeeIDDataSet;
        FindMaterialSheetsByEmployeeIDDataSetTableAdapters.FindMaterialSheetsByEmployeeIDTableAdapter aFindMaterialSheetsByEmployeeIDTableAdapter;

        InventoryLocationDataSet aInventoryLocationDataSet;
        InventoryLocationDataSetTableAdapters.inventorylocationTableAdapter aInventoryLocationTableAdapter;

        InsertInventoryLocationEntryTableAdapters.QueriesTableAdapter aInsertInventoryLocationTableAdapter;

        UpdateInventoryLocationEntryTableAdapters.QueriesTableAdapter aUpdateInventoryLocationTableApapter;

        RemoveInventoryLocationEntryTableAdapters.QueriesTableAdapter aRemoveInventoryLocationTableEntry;

        FindInventoryLocationByPartIDDataSet aFindInventoryLocationByPartIDDataSet;
        FindInventoryLocationByPartIDDataSetTableAdapters.FindInventoryLocationByPartIDTableAdapter aFindInventoryLocationByPartIDTableAdapter;

        FindInventoryLocationByWarehouseDataSet aFindInventoryLocationByWarehouseDataSet;
        FindInventoryLocationByWarehouseDataSetTableAdapters.FindInventoryLocationByWarehouseTableAdapter aFindInventoryLocationByWarehouseTableAdapter;

        FindInventoryLocationByLocationDataSet aFindInventoryLocationByLocationDataSet;
        FindInventoryLocationByLocationDataSetTableAdapters.FindInventoryLocationByLocationTableAdapter aFindInventoryLocationByLocationTableAdapter;

        public FindInventoryLocationByLocationDataSet FindInventoryLocationByLocation(string strPartLocation, int intWarehouseID)
        {
            try
            {
                aFindInventoryLocationByLocationDataSet = new FindInventoryLocationByLocationDataSet();
                aFindInventoryLocationByLocationTableAdapter = new FindInventoryLocationByLocationDataSetTableAdapters.FindInventoryLocationByLocationTableAdapter();
                aFindInventoryLocationByLocationTableAdapter.Fill(aFindInventoryLocationByLocationDataSet.FindInventoryLocationByLocation, strPartLocation, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheets Class // Find Inventory Location By Location " + Ex.Message);
            }

            return aFindInventoryLocationByLocationDataSet;
        }
        public FindInventoryLocationByWarehouseDataSet FindInventoryLocationByWarehouse(int intWarehouseID)
        {
            try
            {
                aFindInventoryLocationByWarehouseDataSet = new FindInventoryLocationByWarehouseDataSet();
                aFindInventoryLocationByWarehouseTableAdapter = new FindInventoryLocationByWarehouseDataSetTableAdapters.FindInventoryLocationByWarehouseTableAdapter();
                aFindInventoryLocationByWarehouseTableAdapter.Fill(aFindInventoryLocationByWarehouseDataSet.FindInventoryLocationByWarehouse, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheets Class // Find Inventory Location By Warehouse " + Ex.Message);
            }

            return aFindInventoryLocationByWarehouseDataSet;
        }
        public FindInventoryLocationByPartIDDataSet FindInventoryLocationByPartID(int intPartID, int intWarehouseID)
        {
            try
            {
                aFindInventoryLocationByPartIDDataSet = new FindInventoryLocationByPartIDDataSet();
                aFindInventoryLocationByPartIDTableAdapter = new FindInventoryLocationByPartIDDataSetTableAdapters.FindInventoryLocationByPartIDTableAdapter();
                aFindInventoryLocationByPartIDTableAdapter.Fill(aFindInventoryLocationByPartIDDataSet.FindInventoryLocationByPartID, intPartID, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Find Inventory Location By Part ID " + Ex.Message);
            }

            return aFindInventoryLocationByPartIDDataSet;
        }
        public bool RemoveInventoryLocation(int intTransactionID)
        {
            bool blnFatalError = false;

            try
            {
                aRemoveInventoryLocationTableEntry = new RemoveInventoryLocationEntryTableAdapters.QueriesTableAdapter();
                aRemoveInventoryLocationTableEntry.RemoveInventoryLocation(intTransactionID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheets Class // Remove Inventory Location " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool UpdateInventoryLocation(int intTransactionID, string strPartLocation)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateInventoryLocationTableApapter = new UpdateInventoryLocationEntryTableAdapters.QueriesTableAdapter();
                aUpdateInventoryLocationTableApapter.UpdateInventoryLocation(intTransactionID, strPartLocation);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheets Class // Update Inventory Location " + Ex.Message);

                blnFatalError = true
            }

            return blnFatalError;
        }
        public bool InsertInventoryLocation(int intPartID, int intEmployeeID, DateTime datCreateDate, string strPartLocation, int intWarehouseID)
        {
            bool blnFatalError = false;

            try
            {
                aInsertInventoryLocationTableAdapter = new InsertInventoryLocationEntryTableAdapters.QueriesTableAdapter();
                aInsertInventoryLocationTableAdapter.InsertInventoryLocation(intPartID, intEmployeeID, datCreateDate, strPartLocation, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheet Class // Insert Inventory Location " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public InventoryLocationDataSet GetInventoryLocationInfo()
        {
            try
            {
                aInventoryLocationDataSet = new InventoryLocationDataSet();
                aInventoryLocationTableAdapter = new InventoryLocationDataSetTableAdapters.inventorylocationTableAdapter();
                aInventoryLocationTableAdapter.Fill(aInventoryLocationDataSet.inventorylocation);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheets Class // Get Inventory Location Info " + Ex.Message);
            }                

            return aInventoryLocationDataSet;
        }
        public void UpdateInventoryLocationDB(InventoryLocationDataSet aInventoryLocationDataSet)
        {
            try
            {
                aInventoryLocationTableAdapter = new InventoryLocationDataSetTableAdapters.inventorylocationTableAdapter();
                aInventoryLocationTableAdapter.Update(aInventoryLocationDataSet.inventorylocation);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheets Class // Update Inventory Location DB " + Ex.Message);
            }
        }
        public FindMaterialSheetsByEmployeeIDDataSet FindMaterialSheetsByEmployeeID(int intEmployeeID)
        {
            try
            {
                aFindMaterialSheetsByEmployeeIDDataSet = new FindMaterialSheetsByEmployeeIDDataSet();
                aFindMaterialSheetsByEmployeeIDTableAdapter = new FindMaterialSheetsByEmployeeIDDataSetTableAdapters.FindMaterialSheetsByEmployeeIDTableAdapter();
                aFindMaterialSheetsByEmployeeIDTableAdapter.Fill(aFindMaterialSheetsByEmployeeIDDataSet.FindMaterialSheetsByEmployeeID, intEmployeeID);
            }
            catch (Exception ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheets Class // Find Material Sheets By Employee ID " + ex.Message);
            }

            return aFindMaterialSheetsByEmployeeIDDataSet;
        }
        public FindMaterialSheetByPartIDDataSet FindMaterialSheetByPartID(int intPartID)
        {
            try
            {
                aFindMaterialSheetByPartIDDataSet = new FindMaterialSheetByPartIDDataSet();
                aFindMaterialSheetByPartIDTableAdapter = new FindMaterialSheetByPartIDDataSetTableAdapters.FindMaterialSheetByPartIDTableAdapter();
                aFindMaterialSheetByPartIDTableAdapter.Fill(aFindMaterialSheetByPartIDDataSet.FindMaterialSheetByPartID, intPartID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheet Class // Find Material Sheet By Part ID " + Ex.Message);
            }

            return aFindMaterialSheetByPartIDDataSet;
        }
        public FindMaterialSheetEntryByPartIDSheetIDWarehouseIDDataSet FindMaterialSheetEntryByPartIDSheetIDWarehouseID(int intPartID, int intSheetTypeID, int intWarehouseID)
        {
            try
            {
                aFindMaterialSheetEntryByPartIDSheetIDWarehouseIDDataSet = new FindMaterialSheetEntryByPartIDSheetIDWarehouseIDDataSet();
                aFindMaterialSheetEntryByPartIDSheetIDWarehouseIDTableAdapter = new FindMaterialSheetEntryByPartIDSheetIDWarehouseIDDataSetTableAdapters.FindMaterialSheetEntryByPartIDSheetIDWarehouseIDTableAdapter();
                aFindMaterialSheetEntryByPartIDSheetIDWarehouseIDTableAdapter.Fill(aFindMaterialSheetEntryByPartIDSheetIDWarehouseIDDataSet.FindMaterialSheetEntryByPartIDSheetIDWarehouseID, intPartID, intSheetTypeID, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheet Class // Find Material Sheet Entry By Part ID Sheet ID Warehouse ID " + Ex.Message);
            }

            return aFindMaterialSheetEntryByPartIDSheetIDWarehouseIDDataSet;
        }
        public CreateMaterialSheetDataSet CreateMaterialSheet(int intSheetTypeID, int intWarehouseID)
        {
            try
            {
                aCreateMaterialSheetDataSet = new CreateMaterialSheetDataSet();
                aCreateMaterialSheetTableAdapter = new CreateMaterialSheetDataSetTableAdapters.CreateMaterialSheetTableAdapter();
                aCreateMaterialSheetTableAdapter.Fill(aCreateMaterialSheetDataSet.CreateMaterialSheet, intSheetTypeID, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheets Class // Create Material Sheet " + Ex.Message);
            }

            return aCreateMaterialSheetDataSet;
        }
        public bool InsertMaterialSheet(int intPartID, int intSheetTypeID, int intEmployeeID, DateTime datCreateDate)
        {
            bool blnFatalError = false;

            try
            {
                aInsertMaterialSheetTableAdapter = new InsertMaterialSheetEntryTableAdapters.QueriesTableAdapter();
                aInsertMaterialSheetTableAdapter.InsertMaterialSheet(intPartID, intSheetTypeID, intEmployeeID, datCreateDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheet Class // Insert Material Sheet " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public MaterialSheetsDataSet GetMaterialSheetInfo()
        {
            try
            {
                aMaterialSheetsDataSet = new MaterialSheetsDataSet();
                aMaterialSheetTableAdapter = new MaterialSheetsDataSetTableAdapters.materialsheetsTableAdapter();
                aMaterialSheetTableAdapter.Fill(aMaterialSheetsDataSet.materialsheets);
            }
            catch (Exception ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheet Class // Get Material Sheet Info " + ex.Message);
            }

            return aMaterialSheetsDataSet;
        }
        public void UpdateMaterialSheetDB(MaterialSheetsDataSet aMaterialSheetsDataSet)
        {
            try
            {
                aMaterialSheetTableAdapter = new MaterialSheetsDataSetTableAdapters.materialsheetsTableAdapter();
                aMaterialSheetTableAdapter.Update(aMaterialSheetsDataSet.materialsheets);
            }
            catch (Exception ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheet Class // Update Material Sheet DB " + ex.Message);
            }
        }
        public FindMaterialSheetTypeBySheetTypeIDDataSet FindMaterialSheetTypeBySheetTypeID(int intSheetTypeID)
        {
            try
            {
                aFindMaterialSheetTypeBySheetTypeIDDataSet = new FindMaterialSheetTypeBySheetTypeIDDataSet();
                aFindMaterialSheetTypeBySheetTypeIDTableAdapter = new FindMaterialSheetTypeBySheetTypeIDDataSetTableAdapters.FindMaterialSheetTypeBySheetTypeIDTableAdapter();
                aFindMaterialSheetTypeBySheetTypeIDTableAdapter.Fill(aFindMaterialSheetTypeBySheetTypeIDDataSet.FindMaterialSheetTypeBySheetTypeID, intSheetTypeID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheet Class // Find Material Sheet Type By Sheet Type ID " + Ex.Message);
            }

            return aFindMaterialSheetTypeBySheetTypeIDDataSet;
        }
        public FindMaterialSheetTypeBySheetTypeDataSet FindMaterialSheeTTypeBySheetType(string strSheetType)
        {
            try
            {
                aFindMaterialSheetTypeBySheetTypeDataSet = new FindMaterialSheetTypeBySheetTypeDataSet();
                aFindMaterialSheetTypeBySheetTypeTableAdapter = new FindMaterialSheetTypeBySheetTypeDataSetTableAdapters.FindMaterialSheetTypeBySheetTypeTableAdapter();
                aFindMaterialSheetTypeBySheetTypeTableAdapter.Fill(aFindMaterialSheetTypeBySheetTypeDataSet.FindMaterialSheetTypeBySheetType, strSheetType):
            }
            catch(Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheet Class // Find Material Sheet Type By Sheet Type " + Ex.Message);
            }

            return aFindMaterialSheetTypeBySheetTypeDataSet;
        }
        public FindSortedMaterialSheetTypesDataSet FindSortedMaterialSheetTypes()
        {
            try
            {
                aFindSortedMaterialSheetTypesDataSet = new FindSortedMaterialSheetTypesDataSet();
                aFindSortedMaterialSheetTypesTableAdapter = new FindSortedMaterialSheetTypesDataSetTableAdapters.FindSortedMaterialSheetTypesTableAdapter();
                aFindSortedMaterialSheetTypesTableAdapter.Fill(aFindSortedMaterialSheetTypesDataSet.FindSortedMaterialSheetTypes):
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheet Class // Find Sorted Material Sheet Types " + Ex.Message);
            }

            return aFindSortedMaterialSheetTypesDataSet;
        }
        public bool InsertMaterialSheetTypes(string strSheetType)
        {
            bool blnFatalError = false;

            try
            {
                aInsertMaterialSheetTypeTableAdapter = new InsertMaterialSheetTypeEntryTableAdapters.QueriesTableAdapter();
                aInsertMaterialSheetTypeTableAdapter.InsertMaterialSheetType(strSheetType);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheets Class // Insert Material Sheet Types " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public MaterialSheetTypesDataSet GetMaterialSheetTypesInfo()
        {
            try
            {
                aMaterialSheetTypesDataSet = new MaterialSheetTypesDataSet();
                aMaterialSheetTypesTableAdapter = new MaterialSheetTypesDataSetTableAdapters.materialsheettypesTableAdapter();
                aMaterialSheetTypesTableAdapter.Fill(aMaterialSheetTypesDataSet.materialsheettypes);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheet Class // Get Material Sheet Info " + Ex.Message);
            }

            return aMaterialSheetTypesDataSet;
        }
        public void UpdateMaterialSheetTypesDB(MaterialSheetTypesDataSet aMaterialSheetTypesDataSet)
        {
            try
            {
                aMaterialSheetTypesTableAdapter = new MaterialSheetTypesDataSetTableAdapters.materialsheettypesTableAdapter();
                aMaterialSheetTypesTableAdapter.Update(aMaterialSheetTypesDataSet.materialsheettypes);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Material Sheet Class // Update Material Sheet DB " + Ex.Message);
            }
        }
    }
}
