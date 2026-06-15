// Reusable table search / pagination / export
(function(){
  document.querySelectorAll('[data-table]').forEach(initTable);

  function initTable(table){
    const wrap=table.closest('.table-wrap')?.parentElement || table.parentElement;
    const searchInput=wrap.querySelector('[data-search]');
    const pageSize=parseInt(table.dataset.pageSize||'8',10);
    const rows=Array.from(table.tBodies[0].rows);
    let filtered=rows.slice();
    let page=1;

    function render(){
      rows.forEach(r=>r.style.display='none');
      const start=(page-1)*pageSize;
      filtered.slice(start,start+pageSize).forEach(r=>r.style.display='');
      renderPagination();
    }
    function renderPagination(){
      const pag=wrap.querySelector('[data-pagination]');
      if(!pag) return;
      const pages=Math.max(1,Math.ceil(filtered.length/pageSize));
      pag.innerHTML='';
      const prev=btn('‹',()=>{if(page>1){page--;render();}});
      pag.appendChild(prev);
      for(let i=1;i<=pages;i++){
        const b=btn(i,()=>{page=i;render();});
        if(i===page) b.classList.add('active');
        pag.appendChild(b);
      }
      pag.appendChild(btn('›',()=>{if(page<pages){page++;render();}}));
    }
    function btn(label,fn){const b=document.createElement('button');b.textContent=label;b.addEventListener('click',fn);return b;}

    if(searchInput){
      searchInput.addEventListener('input',()=>{
        const q=searchInput.value.toLowerCase();
        filtered=rows.filter(r=>r.textContent.toLowerCase().includes(q));
        page=1;render();
      });
    }
    wrap.querySelectorAll('[data-filter]').forEach(sel=>{
      sel.addEventListener('change',()=>{
        const col=parseInt(sel.dataset.filter,10);
        const val=sel.value.toLowerCase();
        filtered=rows.filter(r=>!val || (r.cells[col]?.textContent.toLowerCase().includes(val)));
        page=1;render();
      });
    });
    wrap.querySelectorAll('[data-export="csv"]').forEach(b=>{
      b.addEventListener('click',()=>exportCSV(table));
    });
    wrap.querySelectorAll('[data-export="pdf"]').forEach(b=>{
      b.addEventListener('click',()=>window.print());
    });
    // Row delete buttons
    table.addEventListener('click',e=>{
      const del=e.target.closest('[data-row-delete]');
      if(del){
        const tr=del.closest('tr');
        const idx=filtered.indexOf(tr);
        if(idx>=0) filtered.splice(idx,1);
        const idx2=rows.indexOf(tr);
        if(idx2>=0) rows.splice(idx2,1);
        tr.remove();
        render();
      }
    });
    render();
  }

  function exportCSV(table){
    const lines=[];
    const head=Array.from(table.tHead.rows[0].cells).slice(0,-1).map(c=>'"'+c.innerText.trim()+'"').join(',');
    lines.push(head);
    Array.from(table.tBodies[0].rows).forEach(r=>{
      if(r.style.display==='none') return;
      const cells=Array.from(r.cells).slice(0,-1).map(c=>'"'+c.innerText.replace(/\s+/g,' ').trim().replace(/"/g,'""')+'"');
      lines.push(cells.join(','));
    });
    const blob=new Blob([lines.join('\n')],{type:'text/csv'});
    const a=document.createElement('a');
    a.href=URL.createObjectURL(blob);
    a.download='export.csv';
    a.click();
  }
})();
