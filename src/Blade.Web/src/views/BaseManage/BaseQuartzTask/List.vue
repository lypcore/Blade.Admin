<template>
  <a-card :bordered="false">
    <div class="table-operator">
      <a-button type="primary" icon="plus" @click="hanldleAdd()">新建</a-button>
      <a-button
        type="primary"
        icon="minus"
        @click="handleDelete(selectedRowKeys)"
        :disabled="!hasSelected()"
        :loading="loading"
      >删除</a-button>
      <a-button type="primary" icon="redo" @click="getDataList()">刷新</a-button>
    </div>

    <div class="table-page-search-wrapper">
      <a-form layout="inline">
        <a-row :gutter="10">
          <a-col :md="4" :sm="24">
            <a-form-item label="查询类别">
              <a-select allowClear v-model="queryParam.condition">
                <a-select-option key="JobName">任务名称</a-select-option>
                <a-select-option key="JobGroup">任务所属分组</a-select-option>
                <a-select-option key="JobClassName">任务类名</a-select-option>
                <a-select-option key="JobDescription">任务描述</a-select-option>
                <a-select-option key="CronSecond">秒</a-select-option>
                <a-select-option key="CronMinute">分钟</a-select-option>
                <a-select-option key="CronHour">小时</a-select-option>
                <a-select-option key="CronDay">日</a-select-option>
                <a-select-option key="CronMonth">月</a-select-option>
                <a-select-option key="CronWeek">星期</a-select-option>
                <a-select-option key="CronYear">年</a-select-option>
                <a-select-option key="Message">执行信息</a-select-option>
                <a-select-option key="SimpleTriggerRepeatCount">重复执行次数</a-select-option>
                <a-select-option key="SimpleTriggerRepeatSeconds">重复执行时间间隔</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="4" :sm="24">
            <a-form-item>
              <a-input v-model="queryParam.keyword" placeholder="关键字" />
            </a-form-item>
          </a-col>
          <a-col :md="6" :sm="24">
            <a-button type="primary" @click="() => {this.pagination.current = 1; this.getDataList()}">查询</a-button>
            <a-button style="margin-left: 8px" @click="() => (queryParam = {})">重置</a-button>
          </a-col>
        </a-row>
      </a-form>
    </div>

    <a-table
      ref="table"
      :columns="columns"
      :rowKey="row => row.Id"
      :dataSource="data"
      :pagination="pagination"
      :loading="loading"
      @change="handleTableChange"
      :rowSelection="{ selectedRowKeys: selectedRowKeys, onChange: onSelectChange }"
      :bordered="true"
      size="small"
    >
      <span slot="action" slot-scope="text, record">
        <template>
          <a @click="handleEdit(record.Id)">编辑</a>
          <a-divider type="vertical" />
          <a @click="handleDelete([record.Id])">删除</a>
        </template>
      </span>
    </a-table>

    <edit-form ref="editForm" :parentObj="this"></edit-form>
  </a-card>
</template>

<script>
import EditForm from './EditForm'

const columns = [
  { title: '任务名称', dataIndex: 'JobName', width: '10%' },
  { title: '任务所属分组', dataIndex: 'JobGroup', width: '10%' },
  { title: '任务类名', dataIndex: 'JobClassName', width: '10%' },
  { title: '任务描述', dataIndex: 'JobDescription', width: '10%' },
  { title: '运行状态 0：未运行 10：运行中 20：暂停', dataIndex: 'RunStatus', width: '10%' },
  { title: '0：禁用 1：启用', dataIndex: 'Enabled', width: '10%' },
  { title: '开始运行时间', dataIndex: 'StarRunTime', width: '10%' },
  { title: '运行结束时间', dataIndex: 'EndRunTime', width: '10%' },
  { title: '秒', dataIndex: 'CronSecond', width: '10%' },
  { title: '分钟', dataIndex: 'CronMinute', width: '10%' },
  { title: '小时', dataIndex: 'CronHour', width: '10%' },
  { title: '日', dataIndex: 'CronDay', width: '10%' },
  { title: '月', dataIndex: 'CronMonth', width: '10%' },
  { title: '星期', dataIndex: 'CronWeek', width: '10%' },
  { title: '年', dataIndex: 'CronYear', width: '10%' },
  { title: '执行信息', dataIndex: 'Message', width: '10%' },
  { title: '重复执行次数', dataIndex: 'SimpleTriggerRepeatCount', width: '10%' },
  { title: '重复执行时间间隔', dataIndex: 'SimpleTriggerRepeatSeconds', width: '10%' },
  { title: '操作', dataIndex: 'action', scopedSlots: { customRender: 'action' } }
]

export default {
  components: {
    EditForm
  },
  mounted() {
    this.getDataList()
  },
  data() {
    return {
      data: [],
      pagination: {
        current: 1,
        pageSize: 10,
        showTotal: (total, range) => `总数:${total} 当前:${range[0]}-${range[1]}`
      },
      filters: {},
      sorter: { field: 'Id', order: 'asc' },
      loading: false,
      columns,
      queryParam: {},
      selectedRowKeys: []
    }
  },
  methods: {
    handleTableChange(pagination, filters, sorter) {
      this.pagination = { ...pagination }
      this.filters = { ...filters }
      this.sorter = { ...sorter }
      this.getDataList()
    },
    getDataList() {
      this.selectedRowKeys = []

      this.loading = true
      this.$http
        .post('/BaseManage/BaseQuartzTask/GetDataList', {
          PageIndex: this.pagination.current,
          PageRows: this.pagination.pageSize,
          SortField: this.sorter.field || 'Id',
          SortType: this.sorter.order,
          Search: this.queryParam,
          ...this.filters
        })
        .then(resJson => {
          this.loading = false
          this.data = resJson.Data
          const pagination = { ...this.pagination }
          pagination.total = resJson.Total
          this.pagination = pagination
        })
    },
    onSelectChange(selectedRowKeys) {
      this.selectedRowKeys = selectedRowKeys
    },
    hasSelected() {
      return this.selectedRowKeys.length > 0
    },
    hanldleAdd() {
      this.$refs.editForm.openForm()
    },
    handleEdit(id) {
      this.$refs.editForm.openForm(id)
    },
    handleDelete(ids) {
      var thisObj = this
      this.$confirm({
        title: '确认删除吗?',
        onOk() {
          return new Promise((resolve, reject) => {
            thisObj.$http.post('/BaseManage/BaseQuartzTask/DeleteData', ids).then(resJson => {
              resolve()

              if (resJson.Success) {
                thisObj.$message.success('操作成功!')

                thisObj.getDataList()
              } else {
                thisObj.$message.error(resJson.Msg)
              }
            })
          })
        }
      })
    }
  }
}
</script>