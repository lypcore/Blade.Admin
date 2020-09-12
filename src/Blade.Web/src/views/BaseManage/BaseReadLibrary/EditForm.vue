<template>
  <a-modal
    :title="title"
    width="40%"
    :visible="visible"
    :confirmLoading="loading"
    @ok="handleSubmit"
    @cancel="()=>{this.visible=false}"
  >
    <a-spin :spinning="loading">
      <a-form-model ref="form" :model="entity" :rules="rules" v-bind="layout">
        <a-form-model-item label="描述" prop="Des">
          <a-input v-model="entity.Des" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="权重" prop="HitRate">
          <a-input-number v-model="entity.HitRate" :min="0" :max="100" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="连接字符串" prop="ConnectionString">
          <a-input v-model="entity.ConnectionString" type="textarea" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="是否启用" prop="IsEnable">
          <a-radio-group v-model="entity.IsEnable">
            <a-radio :value="0">禁用</a-radio>
            <a-radio :value="1">启用</a-radio>
          </a-radio-group>
        </a-form-model-item>
        <a-form-item label="数据库类型" prop="DbType">
          <a-select allowClear v-model="entity.DbType">
            <a-select-option key="SqlServer">SqlServer</a-select-option>
              <a-select-option key="MySql">MySql</a-select-option>
              <a-select-option key="Oracle">Oracle</a-select-option>
              <a-select-option key="PostgreSql">PostgreSql</a-select-option>
            </a-select>
          </a-form-item>
      </a-form-model>
    </a-spin>
  </a-modal>
</template>

<script>
export default {
  props: {
    parentObj: Object
  },
  data() {
    return {
      layout: {
        labelCol: { span: 5 },
        wrapperCol: { span: 18 }
      },
      visible: false,
      loading: false,
      entity: {},
      rules: {},
      title: ''
    }
  },
  methods: {
    init() {
      this.visible = true
      this.entity = {}
      this.$nextTick(() => {
        this.$refs['form'].clearValidate()
      })
    },
    openForm(id, title) {
      this.init()

      if (id) {
        this.loading = true
        this.$http.post('/BaseManage/BaseReadLibrary/GetTheData', { id: id }).then(resJson => {
          this.loading = false

          this.entity = resJson.Data
        })
      }
    },
    handleSubmit() {
      this.$refs['form'].validate(valid => {
        if (!valid) {
          return
        }
        this.loading = true
        this.$http.post('/BaseManage/BaseReadLibrary/SaveData', this.entity).then(resJson => {
          this.loading = false

          if (resJson.Success) {
            this.$message.success('操作成功!')
            this.visible = false

            this.parentObj.getDataList()
          } else {
            this.$message.error(resJson.Msg)
          }
        })
      })
    }
  }
}
</script>
