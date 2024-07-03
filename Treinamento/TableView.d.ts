// Importe o tipo Vue se estiver usando TypeScript
import { ComponentOptions } from 'vue';

// Declare o tipo para o componente TableView.vue
declare module '*.vue' {
  const component: ComponentOptions;
  export default component;
}