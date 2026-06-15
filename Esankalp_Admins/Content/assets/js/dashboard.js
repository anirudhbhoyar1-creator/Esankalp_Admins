// Dashboard charts
(function(){
  if(typeof Chart === 'undefined') return;
  Chart.defaults.color = '#9fb3d1';
  Chart.defaults.borderColor = 'rgba(255,255,255,.08)';

  const c1=document.getElementById('revenueChart');
  if(c1){
    const ctx=c1.getContext('2d');
    const grad=ctx.createLinearGradient(0,0,0,260);
    grad.addColorStop(0,'rgba(0,168,255,.55)');
    grad.addColorStop(1,'rgba(0,168,255,0)');
    const grad2=ctx.createLinearGradient(0,0,0,260);
    grad2.addColorStop(0,'rgba(255,152,0,.45)');
    grad2.addColorStop(1,'rgba(255,152,0,0)');
    new Chart(ctx,{
      type:'line',
      data:{
        labels:['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'],
        datasets:[
          {label:'Income',data:[42,55,49,72,80,68,90,102,96,118,128,140],borderColor:'#00A8FF',backgroundColor:grad,tension:.4,fill:true,borderWidth:2,pointRadius:0},
          {label:'Expenses',data:[28,34,30,40,46,38,52,58,55,66,70,78],borderColor:'#FF9800',backgroundColor:grad2,tension:.4,fill:true,borderWidth:2,pointRadius:0},
        ]
      },
      options:{responsive:true,maintainAspectRatio:false,plugins:{legend:{position:'bottom'}},
        scales:{y:{grid:{color:'rgba(255,255,255,.06)'}},x:{grid:{display:false}}}
      }
    });
  }
  const c2=document.getElementById('categoryChart');
  if(c2){
    new Chart(c2.getContext('2d'),{
      type:'doughnut',
      data:{labels:['Web','Mobile','AI/ML','Cloud'],
        datasets:[{data:[42,28,18,12],backgroundColor:['#00A8FF','#FF9800','#3ddc97','#a878ff'],borderWidth:0}]},
      options:{cutout:'70%',plugins:{legend:{position:'bottom'}}}
    });
  }
  const c3=document.getElementById('trafficChart');
  if(c3){
    new Chart(c3.getContext('2d'),{
      type:'bar',
      data:{labels:['Mon','Tue','Wed','Thu','Fri','Sat','Sun'],
        datasets:[{label:'Visits',data:[120,180,150,210,190,260,230],backgroundColor:'#00A8FF',borderRadius:6}]},
      options:{responsive:true,maintainAspectRatio:false,plugins:{legend:{display:false}},
        scales:{y:{grid:{color:'rgba(255,255,255,.06)'}},x:{grid:{display:false}}}}
    });
  }

  // Income/Expense charts
  const ic=document.getElementById('incomeChart');
  if(ic){
    new Chart(ic.getContext('2d'),{type:'bar',
      data:{labels:['W1','W2','W3','W4'],datasets:[{label:'Income (k)',data:[24,32,28,40],backgroundColor:'#00A8FF',borderRadius:6}]},
      options:{maintainAspectRatio:false,plugins:{legend:{display:false}},scales:{y:{grid:{color:'rgba(255,255,255,.06)'}},x:{grid:{display:false}}}}
    });
  }
  const ec=document.getElementById('expenseChart');
  if(ec){
    new Chart(ec.getContext('2d'),{type:'bar',
      data:{labels:['W1','W2','W3','W4'],datasets:[{label:'Expense (k)',data:[14,18,16,22],backgroundColor:'#FF9800',borderRadius:6}]},
      options:{maintainAspectRatio:false,plugins:{legend:{display:false}},scales:{y:{grid:{color:'rgba(255,255,255,.06)'}},x:{grid:{display:false}}}}
    });
  }
})();
