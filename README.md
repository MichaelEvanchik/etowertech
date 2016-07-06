# etowertech usage
   
          eTowerPost u = new eTowerPost();

          List<eTower.eTowerOrder> o = u.GetEtowerObjectByExternalRef(115797);
          eTower.eTowerOrderRespone r = u.PostJsonETowerOrder("POST" ,o, "/services/integration/shipper/orders", "application/json");
          
          if(r.status == "Succeeded")
          {
              woot(true,r);
          }
