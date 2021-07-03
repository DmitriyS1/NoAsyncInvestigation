import http from 'k6/http';
import { sleep } from 'k6';

export default function () {
  http.get('http://host.docker.internal:5000/Home/range?start=10&end=128');
  //sleep(1);
  
  let id = Math.round( Math.random() * (14999 - 1200) + 1200);
  let price = Math.round( Math.random() * 58215);

  // console.log("id: ", id);
  // console.log("price: ", price);

  http.post(`http://host.docker.internal:5000/Home/update?id=${id}&newPrice=${price}`)
  //sleep(1)
}
