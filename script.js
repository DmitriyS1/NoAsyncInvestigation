import http from 'k6/http';
import { sleep } from 'k6';

export default function () {
  http.get('http://127.0.0.1:3654/Home/range?start=10&end=128');
  sleep(1);
  
  let id = Math.random() * (14999 - 1200) + 1200
  let price = Math.random * 58215
  http.post(`http://127.0.0.1:3654/Home/update?id=${id}&newPrice=${price}`)
  sleep(1)
}
