<script setup>
//import HelloWorld from './components/HelloWorld.vue'
  //import TheWelcome from './components/TheWelcome.vue'
  import ChildComp from './components/ChildComponent.vue'

  import { ref, reactive, computed, onMounted, watch } from 'vue';

  function increment() {
    counter.count++;
  }

  function onInput(e) {
    text.value = e.target.value;
  }

  const message = ref('Hello!!!');
  const counter = reactive({ count: 0 });
  const title1 = ref('title');
  const title2 = ref('title2');
  const text = ref('')

  const isGood = ref(true)

  function toggle() {
    isGood.value = !isGood.value;
  }

  let id = 0;
  const todoList = ref([
    { id: id++, text: 'Текст' + id, done: true},
    { id: id++, text: 'Текст' + id, done: false},
    { id: id++, text: 'Текст' + id, done: true}
  ])

  const hideComplited = ref(true);

  const filteredTodoList = computed(() => {
    return hideComplited.value
      ? todoList.value.filter(item => !item.done)
      : todoList.value
  })

  const pElementRef = ref(null);

  onMounted(() => {
    pElementRef.value.textContent = 'Mounted';
  })

  //Watch
  const todoId = ref(1);
  const todoData = ref(null);

  async function fetchData() {
    todoData.value = null;
    const result = await fetch(`https://jsonplaceholder.typicode.com/todos/${todoId.value}`);
    todoData.value = await result.json();
  }

  watch(todoId, fetchData);

  const helloMsg = ref('Hello');

</script>

<template>
  <header>
    <img alt="Vue logo" class="logo" src="./assets/logo.svg" width="125" height="125" />

    <div class="wrapper">
      <HelloWorld msg="You did it!" />
    </div>
  </header>

  <main>
    {{ message }}
    <div :class="title2"> Color text</div>
    <button @click="increment">{{ counter.count }}</button>

    <!--2-way binding-->
    <div>
      <!--<input :value="text" @input="onInput">-->
      <input v-model="text">
    </div>
    <p>{{ text }}</p>

    <!--IF-ELSE-->
    <button @click="toggle">Toggle</button>
    <h1 v-if="isGood">GOOD</h1>
    <h1 v-else>NO</h1>

    <!--LIST-->
    <ul>
      <li v-for="todo in todoList" :key="todo.id">{{ todo.text }}</li>
    </ul>

    <!--COMPUTED-->
    <div>COMPUTED</div>
    <ul>
      <li v-for="todo in filteredTodoList" :key="todo.id">
        <input type="checkbox" v-model="todo.done">
        {{ todo.text }}
      </li>
    </ul>
    <button @click="hideComplited = !hideComplited">
      {{ hideComplited ? 'Показать все' : 'Скрыть завершенные'}}
    </button>

    <!--onMOUNT-->
    <p ref="pElementRef">Mount Stage</p>

    <div>
      <!--Watch-->
      <p>{{ todoId }}</p>
      <button @click="todoId++">Другой Id</button>
      <pre>{{ todoData }}</pre>
    </div>

    <div>
      <h2>Parent Component</h2>
      <ChildComp :msg="helloMsg" @response="(msg) => helloMsg = msg">Message from parrent in slot</ChildComp>
      <p>{{ helloMsg }}</p>
    </div>


    <!--<TheWelcome />-->
  </main>
</template>

<style scoped>
.title {
    color: antiquewhite;
}

.title2 {
  color: aquamarine;
}

header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
