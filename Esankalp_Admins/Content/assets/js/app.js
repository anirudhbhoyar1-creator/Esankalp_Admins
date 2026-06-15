// ===== eSankalp Admin Portal - App JS =====
(function(){
  // Floating particles for login
  const p = document.querySelector('.particles');
  if(p){
    for(let i=0;i<28;i++){
      const s=document.createElement('span');
      s.style.left=Math.random()*100+'%';
      s.style.bottom='-'+Math.random()*30+'px';
      const size=2+Math.random()*5;
      s.style.width=size+'px';s.style.height=size+'px';
      s.style.animationDuration=(8+Math.random()*14)+'s';
      s.style.animationDelay=(Math.random()*8)+'s';
      s.style.background = Math.random()>.5 ? '#00A8FF' : '#FF9800';
      s.style.opacity=.25+Math.random()*.4;
      p.appendChild(s);
    }
  }

  // Login submit -> store name and go to dashboard
  const lf=document.getElementById('loginForm');
  if(lf){
    lf.addEventListener('submit',function(e){
      e.preventDefault();
      const name=document.getElementById('fullName').value.trim()||'Admin';
      const mob=document.getElementById('mobile').value.trim();
      try{
        localStorage.setItem('es_user',JSON.stringify({name,mobile:mob,loggedAt:Date.now()}));
      }catch(_){}
      window.location.href='pages/dashboard.html';
    });
  }

  // Sidebar toggle (mobile)
  const sb=document.querySelector('.sidebar');
  const tg=document.getElementById('sidebarToggle');
  const bd=document.getElementById('sidebarBackdrop');
  if(tg && sb){
    tg.addEventListener('click',()=>{
      sb.classList.toggle('open');
      if(bd) bd.classList.toggle('show');
    });
    if(bd) bd.addEventListener('click',()=>{sb.classList.remove('open');bd.classList.remove('show');});
  }

  // Active nav link based on filename
  const path=location.pathname.split('/').pop().toLowerCase();
  document.querySelectorAll('.nav-link-es').forEach(a=>{
    const href=(a.getAttribute('href')||'').toLowerCase();
    if(href && href.endsWith(path)) a.classList.add('active');
  });

  // Greet user
  const greet=document.getElementById('userName');
  if(greet){
    try{
      const u=JSON.parse(localStorage.getItem('es_user')||'{}');
      if(u && u.name) greet.textContent=u.name;
    }catch(_){}
  }

  // Logout
  const lo=document.getElementById('logoutBtn');
  if(lo){lo.addEventListener('click',()=>{localStorage.removeItem('es_user');location.href='../index.html';});}

  // Generic form "save" handlers => toast
  document.querySelectorAll('form[data-toast]').forEach(f=>{
    f.addEventListener('submit',function(e){
      e.preventDefault();
      showToast(f.dataset.toast||'Saved successfully');
      f.reset();
    });
  });
})();

function showToast(msg){
  let host=document.getElementById('toastHost');
  if(!host){
    host=document.createElement('div');
    host.id='toastHost';
    host.style.cssText='position:fixed;top:20px;right:20px;z-index:2000;display:flex;flex-direction:column;gap:8px';
    document.body.appendChild(host);
  }
  const t=document.createElement('div');
  t.textContent=msg;
  t.style.cssText='background:linear-gradient(135deg,#00A8FF,#FF9800);color:#fff;padding:12px 16px;border-radius:10px;box-shadow:0 12px 30px rgba(0,0,0,.4);font-weight:600;font-size:14px';
  host.appendChild(t);
  setTimeout(()=>{t.style.opacity='0';t.style.transition='opacity .4s';},2200);
  setTimeout(()=>t.remove(),2800);
}
