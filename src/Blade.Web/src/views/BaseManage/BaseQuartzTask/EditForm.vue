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
        <a-form-model-item label="任务名称" prop="JobName">
          <a-input v-model="entity.JobName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="任务所属分组" prop="JobGroup">
          <a-input v-model="entity.JobGroup" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="任务类名" prop="JobClassName">
          <a-input v-model="entity.JobClassName" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="任务描述" prop="JobDescription">
          <a-input v-model="entity.JobDescription" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运行状态 0：未运行 10：运行中 20：暂停" prop="RunStatus">
          <a-input v-model="entity.RunStatus" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="0：禁用 1：启用" prop="Enabled">
          <a-input v-model="entity.Enabled" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="开始运行时间" prop="StarRunTime">
          <a-input v-model="entity.StarRunTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="运行结束时间" prop="EndRunTime">
          <a-input v-model="entity.EndRunTime" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="秒" prop="CronSecond">
          <a-input v-model="entity.CronSecond" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="分钟" prop="CronMinute">
          <a-input v-model="entity.CronMinute" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="小时" prop="CronHour">
          <a-input v-model="entity.CronHour" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="日" prop="CronDay">
          <a-input v-model="entity.CronDay" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="月" prop="CronMonth">
          <a-input v-model="entity.CronMonth" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="星期" prop="CronWeek">
          <a-input v-model="entity.CronWeek" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="年" prop="CronYear">
          <a-input v-model="entity.CronYear" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="执行信息" prop="Message">
          <a-input v-model="entity.Message" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="重复执行次数" prop="SimpleTriggerRepeatCount">
          <a-input v-model="entity.SimpleTriggerRepeatCount" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="重复执行时间间隔" prop="SimpleTriggerRepeatSeconds">
          <a-input v-model="entity.SimpleTriggerRepeatSeconds" autocomplete="off" />
        </a-form-model-item>
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
        this.$http.post('/BaseManage/BaseQuartzTask/GetTheData', { id: id }).then(resJson => {
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
        this.$http.post('/BaseManage/BaseQuartzTask/SaveData', this.entity).then(resJson => {
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
